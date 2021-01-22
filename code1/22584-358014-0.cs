If it were me, I'd write a custom wrapper class and put tvanfosson's code into its ToString method.  That way you could still work with the double value, but you'd get the right string representation in just about all cases.  It'd look something like this:
    class FormattedDouble
    { 
        public double Value { get; set; }
        
        protected overrides void ToString()
        {
            // tvanfosson's code to produce the right string
        }
    }
