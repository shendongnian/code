    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    
    public class CTest {
        public string test;
    	public string test2 {get; set;}
    }
    
    public class MyClass
    {
        public static void Main()
        {
            CTest CTest = new CTest();
            Type t=CTest.GetType();
    		FieldInfo fieldTest = t.GetField("test");
            CTest.test = "hello";
    		string test = (string)fieldTest.GetValue(CTest);
    		Console.WriteLine(test);
    		
    		
            PropertyInfo p = t.GetProperty("test2");
            CTest.test2 = "hello2";
            //instruction below makes crash
            string test2 = (string)p.GetValue(CTest,null);
    		Console.WriteLine(test2);
    		
            Console.ReadLine();     
        }
    }
