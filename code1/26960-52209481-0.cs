        string statusCode = ResponseStatusCode.SUCCESS; // Automatically converts to string when needed
        ResponseStatusCode codeByValueOf = ResponseStatusCode.ValueOf(statusCode); // Returns null if not found
        // Implements TypeConverter so you can use it with string conversion methods.
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(ResponseStatusCode));
        ResponseStatusCode code = (ResponseStatusCode) converter.ConvertFromInvariantString(statusCode);
        // You can get a full list of the values
        bool canIterateOverValues = ResponseStatusCode.Values.Any(); 
        // Comparisons are by value of the "Name" property. Not by memory pointer location.
        bool implementsByValueEqualsEqualsOperator = "SUCCESS" == ResponseStatusCode.SUCCESS; 
