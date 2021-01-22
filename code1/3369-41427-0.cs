    public static IEnumerable<T> OrderBy( this IEnumerable<T> input, string queryString) {
        //parse the string into property names
        //Use reflection to get and sort by properties
        //something like
        foreach( string propname in queryString.Split(','))
            input.OrderBy( x => GetPropertyValue( x, propname ) );
        // I used kjetil.watnedal's reflection example
    }
