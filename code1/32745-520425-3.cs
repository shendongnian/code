    using System;
    using System.Reflection;
    namespace ConsoleApplication1{
    	class Class1{
    		static bool checkType(Type propertyType,Type myType){
    			if (propertyType == myType){
    				return true;
    			}
    			Type test = propertyType.BaseType;
    			while (test != typeof(Object)){
    				if (test == myType){
    					return true;
    				}
    				test = test.BaseType;
    			}
    			return false;
    		}
    		[STAThread]
    		static void Main(string[] args){
    			Assembly a = Assembly.GetExecutingAssembly();
    			foreach (Type t in a.GetTypes()){
    				Console.WriteLine("Type: {0}",t.Name);
    				foreach (PropertyInfo p in t.GetProperties()){
    					if (checkType(p.PropertyType,typeof(MyType))){
    						Console.WriteLine("  Property: {0}, {1}",p.Name,p.PropertyType.Name);
    					}
    				}
    			}
    		}
    	}
    	class MyType{
    	}
    	class MyType2 : MyType{
    	}
    	class TestType
    	{
    		public MyType mt{
    			get{return _mt;}
    			set{_mt = value;}
    		}
    		private MyType _mt;
    		public MyType2 mt2
    		{
    			get{return _mt2;}
    			set{_mt2 = value;}
    		}
    		private MyType2 _mt2;
    	}
    }
