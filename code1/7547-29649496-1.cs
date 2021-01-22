    //notice the difference between IDictionary (interface) and Dictionary (class)
	typeof(IDictionary<,>).IsAssignableFrom(typeof(IDictionary<,>)) // true 
	typeof(IDictionary<int, int>).IsAssignableFrom(typeof(IDictionary<int, int>)); // true
    typeof(IDictionary<int, int>).IsAssignableFrom(typeof(Dictionary<int, int>)); // true
	typeof(IDictionary<,>).IsAssignableFrom(typeof(Dictionary<,>)); // false!! in contrast with above line this is little bit unintuitive
