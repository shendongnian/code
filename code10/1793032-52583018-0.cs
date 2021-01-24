    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace threemethods
    {
     public class Operator
     {
        public int Add(int data, int value)
        {
             return data + value;
        }    
        public int Subtract(int data, int value)
        {
            return data - value;
        }
        public int Divide(int data, int value)
        {
             return data / value;
        }
     }
    }
