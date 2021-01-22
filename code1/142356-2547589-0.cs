    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Base
        {
            string Prop { get; set;}
        }
    
        class A : Base
        {
        }
    
        class Test : List<A>
        {
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Test test = new Test();
                    Type myType = test.GetType();
    
                    //string filterCriteria = "IEnumerable`1";
                    Type typeA = Type.GetType("ConsoleApplication1.A");
                    string filterCriteria = "System.Collections.Generic.IEnumerable`1[[" +
                                            typeA.AssemblyQualifiedName +
                                            "]]";
    
                    // Specify the TypeFilter delegate that compares the 
                    // interfaces against filter criteria.
                    TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);
                    Type[] myInterfaces = myType.FindInterfaces(myFilter,
                        filterCriteria);
                    if (myInterfaces.Length > 0)
                    {
                        Console.WriteLine("\n{0} implements the interface {1}.",
                            myType, filterCriteria);
                        for (int j = 0; j < myInterfaces.Length; j++)
                            Console.WriteLine("Interfaces supported: {0}.",
                                myInterfaces[j].ToString());
                    }
                    else
                        Console.WriteLine(
                            "\n{0} does not implement the interface {1}.",
                            myType, filterCriteria);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: " + e.Message);
                }
                catch (TargetInvocationException e)
                {
                    Console.WriteLine("TargetInvocationException: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
    
            public static bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
            {
                // This will be true, if criteria is
                // System.Collections.Generic.IEnumerable`1[[ConsoleApplication1.A, ConsoleApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
                if (typeObj.FullName == criteriaObj.ToString())
                    return true;
                // This will be true, if criteria is
                // IEnumerable`1
                // You will still need to check the generic parameters on the original type
                    // (generic parameters are not exposed on Type instances for interfaces
                else if (typeObj.Name == criteriaObj.ToString())
                    return true;
                else
                    return false;
            }
        }
    }
