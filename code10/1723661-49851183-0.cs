    namespace ConsoleApp1
    {
    	using System;
    	using System.Collections;
    	using System.Collections.Generic;
    	using System.Reflection;
    
    	public class BaseClass<T>
    	{
    		public string prop1
    		{
    			get;
    			set;
    		}
    
    		public List<T> prop2
    		{
    			get;
    			set;
    		} //B is a user-defined type
    	}
    
    	public class DescendentClass<T> : BaseClass<T>
    	{
    	}
    
    	public static class DeepComparer
    	{
    		public static bool IsDeeplyEquivalent(this object current, object other)
    		{
                if (current.Equals(other)) return true;
    			Type currentType = current.GetType();
    			// Assumption, cannot be equivalent if another class (descendent classes??)		
    			if (currentType != other.GetType())
    			{
    				return false;
    			}
    
    			foreach (PropertyInfo propertyInfo in currentType.GetProperties())
    			{
    				object currentValue = propertyInfo.GetValue(current, null);
    				object otherValue = propertyInfo.GetValue(other, null);
    				// Assumption, nulls for a given property are considered equivalent
    				if (currentValue == null && otherValue == null)
    				{
    					continue;
    				}
    
    				// One is null, the other isn't so are not equal
    				if (currentValue == null || otherValue == null)
    				{
    					return false;
    				}
    
    				ICollection currentCollection = currentValue as ICollection;
    				if (currentCollection == null)
    				{
    					// Not a collection, just check equality
    					if (!currentValue.Equals(otherValue))
    					{
    						return false;
    					}
    				}
    				else
    				{
    					// Collection, not interested whether list/array/etc are same object, just that they contain equal elements
    					// questioner guaranteed that all elements are unique				
    					HashSet<object> elements = new HashSet<object>();
    					foreach (object o in currentCollection)
    					{
    						elements.Add(o);
    					}
    
    					List<object> otherElements = new List<object>();
    					foreach (object o in (ICollection)otherValue)
    					{
    						otherElements.Add(o);
    					}
    
    					// cast below can be safely made because we have already asserted that
    					// current and other are the same type
    					if (!elements.SetEquals(otherElements))
    					{
    						return false;
    					}
    				}
    			}
    
    			return true;
    		}
    	}
    
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			BaseClass<int> a1 = new BaseClass<int>{prop1 = "Foo", prop2 = new List<int>{1, 2, 3}};
    			BaseClass<int> a2 = new BaseClass<int>{prop1 = "Foo", prop2 = new List<int>{2, 1, 3}};
    			BaseClass<int> a3 = new BaseClass<int>{prop1 = "Bar", prop2 = new List<int>{2, 1, 3}};
    			BaseClass<string> a4 = new BaseClass<string>{prop1 = "Bar", prop2 = new List<string>()};
    			BaseClass<int> a5 = new BaseClass<int>{prop1 = "Bar", prop2 = new List<int>{1, 3}};
    			DateTime d1 = DateTime.Today;
    			DateTime d2 = DateTime.Today;
    			List<string> s1 = new List<string>{"s1", "s2"};
    			string[] s2 = {"s1", "s2"};
    			BaseClass<DayOfWeek> b1 = new BaseClass<DayOfWeek>{prop1 = "Bar", prop2 = new List<DayOfWeek>{DayOfWeek.Monday, DayOfWeek.Tuesday}};
    			DescendentClass<DayOfWeek> b2 = new DescendentClass<DayOfWeek>{prop1 = "Bar", prop2 = new List<DayOfWeek>{DayOfWeek.Monday, DayOfWeek.Tuesday}};
    			Console.WriteLine("a1 == a2 : " + a1.IsDeeplyEquivalent(a2)); // true, different order ignored
    			Console.WriteLine("a1 == a3 : " + a1.IsDeeplyEquivalent(a3)); // false, different prop1
    			Console.WriteLine("a3 == a4 : " + a3.IsDeeplyEquivalent(a4)); // false, different types
    			Console.WriteLine("a3 == a5 : " + a3.IsDeeplyEquivalent(a5)); // false, difference in list elements
    			Console.WriteLine("d1 == d2 : " + d1.IsDeeplyEquivalent(d2)); // true
    			Console.WriteLine("s1 == s2 : " + s1.IsDeeplyEquivalent(s2)); // false, different types
    			Console.WriteLine("b1 == b2 : " + s1.IsDeeplyEquivalent(s2)); // false, different types
            Console.WriteLine("b1 == b1 : " + b1.IsDeeplyEquivalent(b1)); // true, same object
    			Console.ReadLine();
    		}
    	}
    }
