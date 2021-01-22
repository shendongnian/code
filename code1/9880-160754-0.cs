    string formatString = @"
    using System;
    
    public class ClassName
    {{
        public double TheFunction(double input)
        {{
            {0}
        }}
    }}";
    string entireClass = string.Format(formatString, userInput);
