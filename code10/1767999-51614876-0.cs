    string str = "2323dfdf233fgfgfg ddfdf334"; 
    
    var strings = new List<string>();
    var sb = new StringBuilder();
    var lastCharIsNumber = char.IsDigit(str[0]);
    
    foreach (var c in str) {
    	if (char.IsDigit(c) ) {
    		if (!lastCharIsNumber) {
    		 	strings.Add(sb.ToString());
    			sb.Clear();
    		}
    		lastCharIsNumber = true;
    	}
    	else {
    		if (lastCharIsNumber) {
    		 	strings.Add(sb.ToString());
    			sb.Clear();
    		}
    		lastCharIsNumber = false;
    	}
    	sb.Append(c);
    }
    strings.Add(sb.ToString());
    strings.Dump();
