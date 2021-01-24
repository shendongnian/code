	var tmp = string.Empty;
	var output = input.Split(new []{"\n"}, StringSplitOptions.RemoveEmptyEntries).Aggregate(new StringBuilder(), (a,b) => {
    	if (b.EndsWith(":")) {  // feel free to also check for the size
        	tmp = b;
		}
		else {
    		a.AppendLine((tmp + b).Trim()); // remove space before or after a line
			tmp = string.Empty;
		}
    	return a;
	});
