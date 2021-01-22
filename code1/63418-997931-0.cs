    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using ClrTest.Reflection;
    
    namespace ExceptionAnalyser
    {
        public static class ExceptionAnalyser
        {
            public static ReadOnlyCollection<Type> GetAllExceptions(MethodBase method)
            {
                var exceptionTypes = new HashSet<Type>();
                var visitedMethods = new HashSet<MethodBase>();
                GetAllExceptions(method, exceptionTypes, visitedMethods,  0);
                return exceptionTypes.ToList().AsReadOnly();
            }
    
            private static void GetAllExceptions(MethodBase method, HashSet<Type> exceptionTypes,
                HashSet<MethodBase> visitedMethods, int depth)
            {
                var ilReader = new ILReader(method);
                MethodBase stackTopItem = null;
                foreach (var instruction in ilReader)
                {
                    if (instruction is InlineMethodInstruction)
                    {
                        var methodInstruction = (InlineMethodInstruction)instruction;
    
                        if (methodInstruction.OpCode.StackBehaviourPush == StackBehaviour.Pushref &&
                            (methodInstruction.Method.MemberType & MemberTypes.Constructor) != 0)
                        {
                            stackTopItem = methodInstruction.Method;
                        }
    
                        if (!visitedMethods.Contains(methodInstruction.Method))
                        {
                            visitedMethods.Add(methodInstruction.Method);
                            GetAllExceptions(methodInstruction.Method, exceptionTypes, visitedMethods,
                                depth + 1);
                        }
                    }
                    else
                    {
                        switch (instruction.OpCode.Value)
                        {
                            case 0x7A: // throw
                                if (stackTopItem == null)
                                    throw new InvalidProgramException();
    
                                exceptionTypes.Add(stackTopItem.DeclaringType);
                                break;
                        }
                    }
                }
            }
        }
    }
