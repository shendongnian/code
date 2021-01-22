      /// <summary>
        /// 
        /// Implicit conversion is overloadable operator
        /// In below example i define fakedDouble which can be implicitly cast to touble thanks to implicit operator implemented below
        /// </summary>
    
        class FakeDoble
        {
    
            public string FakedNumber { get; set; }
    
            public FakeDoble(string number)
            {
                FakedNumber = number;
            }
    
            public static implicit operator double(FakeDoble f)
            {
                return Int32.Parse(f.FakedNumber);
            }
        }
    
        class Program
        {
          
            static void Main()
            {
                FakeDoble test = new FakeDoble("123");
                double x = test; //posible thanks to implicit operator
    
            }
    
        }
