    using System;
    using System.Collections.Generic;
    
    namespace Using_Singleton_And_GenericCollection
    {
    	// This is the version trying to incorperate the inheritable singleton and a generic collection
    	abstract class NonGenericBase		// Adding this (class or interface) make the use of collections possible.
    	{
    		public string name;
    		public string desc;
    
    		public void printName()
    		{
    			Console.WriteLine("\t" + name);
    		}
    
    		protected NonGenericBase() { }
    	}
    
    	class Base<T> : NonGenericBase where T : Base<T>, new()
    	{
    		#region Singleton stuff
    
    		protected static T _instance;
    
    		public static T Instance
    		{
    			get
    			{
    				if (_instance == null)
    					_instance = new T();
    				return _instance;
    			}
    			set => _instance = value;
    		}
    
    		#endregion
    
    		//public string name;     // Moved to parent
    		//public string desc;
    
    		protected Base()
    		{
    			name = "Base";
    		}
    	}
    
    
    	class FirstChild : Base<FirstChild>
    	{
    		public int number;      // Should be accessible by the class' static methods
    
    		public FirstChild()
    		{
    			name = "The first child";
    			number = 7;
    		}
    
    		public static void StaticMethod_FirstChild()
    		{
    			Console.WriteLine("\tStaticMethod_FirstChild: I can access all member variables! :-)");
    			Console.WriteLine("\tName: " + Instance.name + ", Number: " + Instance.number);     // This is now working
    		}
    	}
    
    	class SecondChild : Base<SecondChild>
    	{
    		public float myfloat;
    
    		public SecondChild()
    		{
    			name = "The second child";
    			myfloat = 0.3f;
    		}
    
    		public static void StaticMethod_SecondChild()
    		{
    			Console.WriteLine("\tStaticMethod_SecondChild: I can access all member variables! :-)");
    			Console.WriteLine("\tName 2x: " + Instance.name + ", " + Instance.name);       // This is now working
    		}
    	}
    
    
    	class Manager       // Manages instances/singletons which derive from "Base" by using a collection of the Base class
    	{
    		public Dictionary<string, NonGenericBase> itemDict;
    
    		public Manager()
    		{
    			itemDict = new Dictionary<string, NonGenericBase>();
    
    			NonGenericBase addItem;
    
    			addItem = FirstChild.Instance;
    			itemDict.Add(addItem.GetType().Name, addItem);
    
    			addItem = SecondChild.Instance;
    			itemDict.Add(addItem.GetType().Name, addItem);
    		}
    
    		public void DoSomething()
    		{
    			foreach (var item in itemDict)
    			{
    				item.Value.printName();
    			}
    			Console.WriteLine();
    		}
    	}
    
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var sec = new SecondChild();
    
    			Console.WriteLine("Access Singletons");
    			Manager manager = new Manager();
    			manager.DoSomething();
    
    			Console.WriteLine("Change Singletons");
    			manager.itemDict[nameof(FirstChild)].name = "first name changed";
    			SecondChild.Instance.name = "second name changed too";
    			manager.DoSomething();
    
    			Console.WriteLine("Create and change a non-Singleton instance of FirstChild");
    			var initItem = new FirstChild();
    			initItem.printName();
    			initItem.name = "Non-Singleton name changed";
    			initItem.printName();
    			Console.WriteLine();
    
    			Console.WriteLine("Access Singletons");
    			manager.DoSomething();
    
    			Console.WriteLine("Call static method of FirstChild");
    			FirstChild.StaticMethod_FirstChild();         //Simulating the external call of one static method
    			Console.WriteLine();
    
    			Console.ReadKey();
    		}
    	}
    } 
