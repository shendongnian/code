    using System;
    using System.Reflection;
    namespace ConsoleApplication1{
    	class Class1{
    		[STAThread]
    		static void Main(string[] args){
    			Assembly a = Assembly.GetExecutingAssembly();
    			foreach (Type t in a.GetTypes()){
    				Console.WriteLine("Type: {0}",t.Name);
    				foreach (FieldInfo f in t.GetFields()){
    					Console.WriteLine("  Field: {0}, {1}",f.Name,f.FieldType.Name);
    				}
    			}
    		}
    	}
    	class MyType{
    	}
    	class TestType{
    		public MyType mt = new MyType();
    	}
    }    
    
