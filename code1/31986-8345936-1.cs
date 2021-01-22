    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    class ObjectA
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public string PropertyC { get; set; }
        public DateTime PropertyD { get; set; }
    
        public string FieldA;
        public DateTime FieldB;
    }
    
    class ObjectB
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public string PropertyC { get; set; }
        public DateTime PropertyD { get; set; }
    
    
        public string FieldA;
        public DateTime FieldB;
        
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // create two objects with same properties
            ObjectA a = new ObjectA() { PropertyA = "test", PropertyB = "test2", PropertyC = "test3" };
            ObjectB b = new ObjectB() { PropertyA = "test", PropertyB = "test2", PropertyC = "test3" };
    
            // add fields to those objects
            a.FieldA = "hello";
            b.FieldA = "Something differnt";
    
            if (a.ComparePropertiesTo(b))
            {
                Console.WriteLine("objects have the same properties");
            }
            else
            {
                Console.WriteLine("objects have diferent properties!");
            }
    
    
            if (a.CompareFieldsTo(b))
            {
                Console.WriteLine("objects have the same Fields");
            }
            else
            {
                Console.WriteLine("objects have diferent Fields!");
            }
           
            Console.Read();
        }
    }
    
    public static class Utilities
    {
        public static bool ComparePropertiesTo(this Object a, Object b)
        {
            System.Reflection.PropertyInfo[] properties = a.GetType().GetProperties(); // get all the properties of object a
    
            foreach (var property in properties)
            {
                var propertyName = property.Name;
    
                var aValue = a.GetType().GetProperty(propertyName).GetValue(a, null);
                object bValue;
    
                try // try to get the same property from object b. maybe that property does
                    // not exist! 
                {
                    bValue = b.GetType().GetProperty(propertyName).GetValue(b, null);
                }
                catch
                {
                    return false;
                }
                if (aValue == null && bValue == null)
                    continue;
                if (aValue == null && bValue != null)
                    return false;
                if (aValue != null && bValue == null)
                   return false;
                // if properties do not match return false
                if (aValue.GetHashCode() != bValue.GetHashCode())
                {
                    return false;
                }
            }
    
            return true;
        }
    
    
    
        public static bool CompareFieldsTo(this Object a, Object b)
        {
            System.Reflection.FieldInfo[] fields = a.GetType().GetFields(); // get all the properties of object a
    
            foreach (var field in fields)
            {
                var fieldName = field.Name;
    
                var aValue = a.GetType().GetField(fieldName).GetValue(a);
    
                object bValue;
    
                try // try to get the same property from object b. maybe that property does
                // not exist! 
                {
                    bValue = b.GetType().GetField(fieldName).GetValue(b);
                }
                catch
                {
                    return false;
                }
                if (aValue == null && bValue == null)
                   continue;
                if (aValue == null && bValue != null)
                   return false;
                if (aValue != null && bValue == null)
                   return false;
    
                // if properties do not match return false
                if (aValue.GetHashCode() != bValue.GetHashCode())
                {
                    return false;
                }
            }
    
            return true;
        }
    
        
    }
    
    
    
        
