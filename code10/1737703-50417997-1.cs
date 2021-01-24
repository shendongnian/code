    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.Diagnostics;
    using System.Reflection;
    
    namespace StackTraceTest
    {
            public class A
            {
                public static void Main(string[] args)
                {
                    StackTrace stackTrace = new StackTrace();
                    LogInfo(MethodBase.GetCurrentMethod().DeclaringType.Name, stackTrace.GetFrame(0).GetMethod().Name);
                    
                    B newB = new B();
                    newB.methodB();
                    
                    LogInfo(MethodBase.GetCurrentMethod().DeclaringType.Name, stackTrace.GetFrame(0).GetMethod().Name);
    
                    /*for (int i = 0; i < stackTrace.FrameCount;i++)
                    {
                        LogInfo(stackTrace.GetFrame(i).GetType().Name, stackTrace.GetFrame(i).GetMethod().Name);
                    }*/
    
                    Console.ReadLine();
                }
    
                public static void LogInfo(string className, string methodName)
                {
                    string info = ("In class: " +className +" In method: " +methodName);
                    Console.WriteLine(info);
                }
            }
    
            public class B
            {
                
                public void methodB()
                {
                    StackTrace stackTrace = new StackTrace();
                    LogInfo(MethodBase.GetCurrentMethod().DeclaringType.Name, stackTrace.GetFrame(0).GetMethod().Name);
                    
                    C newC = new C();
                    newC.methodC();
                }
    
                public void LogInfo(string className, string methodName)
                {
                    string info = ("In class: " + className + " In method: " + methodName);
                    Console.WriteLine(info);
                }
            }
    
            public class C
            {
                public void methodC()
                {
                    StackTrace stackTrace = new StackTrace();
                    LogInfo(MethodBase.GetCurrentMethod().DeclaringType.Name, stackTrace.GetFrame(0).GetMethod().Name);
                    //Console.WriteLine("StackTrace: {0}", Environment.StackTrace);
                }
    
                public void LogInfo(string className, string methodName)
                {
                    string info = ("In class: " + className + " In method: " + methodName);
                    Console.WriteLine(info);
                }
            }
    }
