    /// <summary>
    /// Given an expression, extract the listed property name; similar to reflection but with familiar LINQ+lambdas.  Technique @via http://stackoverflow.com/a/16647343/1037948
    /// </summary>
    /// <remarks>Cheats and uses the tostring output -- Should consult performance differences</remarks>
    /// <typeparam name="TModel">the model type to extract property names</typeparam>
    /// <typeparam name="TValue">the value type of the expected property</typeparam>
    /// <param name="propertySelector">expression that just selects a model property to be turned into a string</param>
    /// <param name="delimiter">Expression toString delimiter to split from lambda param</param>
    /// <param name="endTrim">Sometimes the Expression toString contains a method call, something like "Convert(x)", so we need to strip the closing part from the end</param>
    /// <returns>indicated property name</returns>
    public static string GetPropertyName<TModel, TValue>(this Expression<Func<TModel, TValue>> propertySelector, char delimiter = '.', char endTrim = ')') {
    			
    	var asString = propertySelector.ToString(); // gives you: "o => o.Whatever"
    	var firstDelim = asString.IndexOf(delimiter); // make sure there is a beginning property indicator; the "." in "o.Whatever" -- this may not be necessary?
    
    	return firstDelim < 0
    		? asString
    		: asString.Substring(firstDelim+1).TrimEnd(endTrim);
    }//--	fn	GetPropertyNameExtended
