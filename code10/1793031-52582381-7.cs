    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace threemethods
    {
        public class Operator
        {
        	public double GetAdd(int data)
    	    {
    	         data = data + 4;
    	         return GetSubtract(data);
    	    }    
            
    	    private  double GetSubtract(double data)
    	    {
    	         data = data - 3;
    	         return GetDivide(data);
    	    }
    
    	    private  double GetDivide(double data)
    	    {
    	         return data / 3;
    	    }
        }
    }
