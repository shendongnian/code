	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Text;
	using System.Reflection;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				string typeName = "ConsoleApplication1.SomeClass, ConsoleApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
				string eventName = "SomeEvent";
				Type declaringType = Type.GetType(typeName);
				object target = Activator.CreateInstance(declaringType);
				EventHandler eventDelegate;
				eventDelegate = GetEventHandler(target, eventName);
				if (eventDelegate == null) { Console.WriteLine("No listeners"); }
				// attach a listener
				SomeClass bleh = (SomeClass)target;
				bleh.SomeEvent += delegate { };
				//
				eventDelegate = GetEventHandler(target, eventName);
				if (eventDelegate == null)
				{ Console.WriteLine("No listeners"); }
				else
				{ Console.WriteLine("Listeners: " + eventDelegate.GetInvocationList().Length); }
				Console.ReadKey();
			}
			static EventHandler GetEventHandler(object classInstance, string eventName)
			{
				Type classType = classInstance.GetType();
				FieldInfo eventField = classType.GetField(eventName, BindingFlags.GetField
																   | BindingFlags.NonPublic
																   | BindingFlags.Instance);
				
				EventHandler eventDelegate = (EventHandler)eventField.GetValue(classInstance);
				
				// eventDelegate will be null if no listeners are attached to the event
				if (eventDelegate == null)
				{
					return null;
				}
				return eventDelegate;
			}
		}
		class SomeClass
		{
			public event EventHandler SomeEvent;
		}
	}
