    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                EmployeeA empA = new EmployeeA();
    
                if (empA.IsImplemented("TestMethod"))
                    empA.TestMethod();
    
                EmployeeB empB = new EmployeeB();
                if (empB.IsImplemented("TestMethod"))
                    empB.TestMethod();
    
    
                Console.ReadLine();
                
            }
    
            public static bool IsImplemented(this IEmp emp, string methodName)
            {
                ImplementedAttribute impAtt;
                MethodInfo info = emp.GetType().GetMethod(methodName);
                impAtt = Attribute.GetCustomAttribute(info, typeof(ImplementedAttribute), false)
                            as ImplementedAttribute;
    
                return (impAtt == null) ? true : impAtt.Implemented;
                
            }
    
        }
    
        public class EmployeeA : IEmp
        {
            #region IEmp Members
    
            [Implemented(false)]
            public void  TestMethod()
            {
                Console.WriteLine("Inside of EmployeeA");
            }
    
            #endregion
        }
    
        public class EmployeeB : IEmp
        {
            #region IEmp Members
    
            [Implemented(true)]
            public void TestMethod()
            {
                Console.WriteLine("Inside of EmployeeB");
            }
    
            #endregion
        }
    
    
        public class ImplementedAttribute : Attribute
        {
            public bool Implemented { get; set; }
    
            public ImplementedAttribute():this(true)
            {
            }
    
            public ImplementedAttribute(bool implemented)
            {
                Implemented = implemented;
            }
        }
    
        public interface IEmp
        {
            void TestMethod();
        }
    
    }
