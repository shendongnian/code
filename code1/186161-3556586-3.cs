    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DoubleProject; <------------------------------------------
    
    namespace DoubleProjectTwo
    {
        class ClassB
        {
            public string textB = "I am in Class B Project Two";
            ClassA classA = new ClassA();
    
            
            public void read()
            {
                textB = classA.read();
            }
        }
    }
