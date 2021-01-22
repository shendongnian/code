    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    
    namespace DictonaryEnumConverter
    {
        enum SomeEnum { x, y, z = 4 };
    
        class Program
        {
            static void Main(string[] args)
            {           
                Dictionary<String, Int32> input =
                   new Dictionary<String, Int32>();
                
                input.Add("a", 0);
                input.Add("b", 1);
                input.Add("c", 4);
    
                Dictionary<String, SomeEnum> output = input.ToDictionary(
                   pair => pair.Key, pair => (SomeEnum)pair.Value);
    
                Debug.Assert(output["a"] == SomeEnum.x);
                Debug.Assert(output["b"] == SomeEnum.y);
                Debug.Assert(output["c"] == SomeEnum.z);
            }
        }
    }
