    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                BaseProduct b =(BaseProduct)System.Activator.CreateInstance(Type.GetType("ConsoleApplication1.Product")
                    ,new object[]{typeof(string)}, 
                    new object[]{"123"}
                );
                //Activator..::.CreateInstance Method (Type, array<Object>[]()[], array<Object>[]()[])
            }
        }
        public class Product: BaseProduct{
            public  Product(string id) { 
            
            }
            public string Id {get;set;}
        
        
       }
    
        public abstract class BaseProduct {
            abstract public string Id { get; set; }
        }
    }
