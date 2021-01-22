    using System;
    using System.Reflection;
    
    public class Test
    {
        public int x = 300;
        
        static void Main()
        {
            Test instance = new Test();
            FieldInfo field = typeof(Test).GetField("x");
            
            MethodInfo converter = typeof(BitConverter).GetMethod("GetBytes", 
                new Type[] {field.FieldType});
            if (converter == null)
            {
                Console.WriteLine("No BitConverter.GetBytes method found for type "
                    + field.FieldType);            
            }
            else
            {
                byte[] bytes = (byte[]) converter.Invoke(null,
                    new object[] {field.GetValue(instance) });
                Console.WriteLine("Byte array: {0}", BitConverter.ToString(bytes));
            }        
        }
    }
