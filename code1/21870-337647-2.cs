    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {    
                // leaving out your implementation to save space...    
            }
        }    
        
        public class SadObject : MoodyObject
        {
            protected override String getMood()
            {
                return "sad";
            }
    
            //specialization
            public void cry()
            {
                Console.WriteLine("wah...boohoo");
            }
        }
    
        public class HappyObject : MoodyObject
        {
            protected override String getMood()
            {
                return "happy";
            }
    
            public void laugh()
            {
                Console.WriteLine("hehehehehehe.");
            }
        }
    }
    
