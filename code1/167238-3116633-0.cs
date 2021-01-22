    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    
    public class ExtensionCollisionDetector
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine
                    ("Usage: ExtensionCollisionDetector <assembly file> [...]");
                return;
            }
            foreach (string file in args)
            {
                Console.WriteLine("Testing {0}...", file);
                DetectCollisions(file);
            }
        }
        
        private static void DetectCollisions(string file)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(file);
                foreach (var method in FindExtensionMethods(assembly))
                {
                    DetectCollisions(method);
                }
            }
            catch (Exception e)
            {
                // Yes, I know catching exception is generally bad. But hey,
                // "something's" gone wrong. It's not going to do any harm to
                // just go onto the next file.
                Console.WriteLine("Error detecting collisions: {0}", e.Message);
            }
        }
        
        private static IEnumerable<MethodBase> FindExtensionMethods
            (Assembly assembly)
        {
            return from type in assembly.GetTypes()
                   from method in type.GetMethods(BindingFlags.Static |
                                                  BindingFlags.Public |
                                                  BindingFlags.NonPublic)
                   where method.IsDefined(typeof(ExtensionAttribute), false)
                   select method;
        }
        
        
        private static void DetectCollisions(MethodBase method)
        {
            Console.WriteLine("  Testing {0}.{1}", 
                              method.DeclaringType.Name, method.Name);
            Type extendedType = method.GetParameters()[0].ParameterType;
            foreach (var type in GetTypeAndAncestors(extendedType).Distinct())
            {
                foreach (var collision in DetectCollidingMethods(method, type))
                {
                    Console.WriteLine("    Possible collision in {0}: {1}",
                                      collision.DeclaringType.Name, collision);
                }
            }
        }
        
        private static IEnumerable<Type> GetTypeAndAncestors(Type type)
        {
            yield return type;
            if (type.BaseType != null)
            {
                // I want yield foreach!
                foreach (var t in GetTypeAndAncestors(type.BaseType))
                {
                    yield return t;
                }
            }
            foreach (var t in type.GetInterfaces()
                                  .SelectMany(iface => GetTypeAndAncestors(iface)))
            {
                yield return t;
            }        
        }
        
        private static IEnumerable<MethodBase>
            DetectCollidingMethods(MethodBase extensionMethod, Type type)
        {
            // Very, very crude to start with
            return type.GetMethods(BindingFlags.Instance |
                                   BindingFlags.Public |
                                   BindingFlags.NonPublic)
                       .Where(candidate => candidate.Name == extensionMethod.Name);
        }
    }
