	string str = "Psppsp palm springs airport, 3400 e tahquitz canyon way, Palm springs, CA, US, 92262-6966 psppsp";
	string match = "psppsp";
	
	// Build 2 re-usable regexes
	string pattern1 = "^" + match + "\\s*";
	string pattern2 = "\\s*" + match + "$";
	Regex rgx1 = new Regex(pattern1, RegexOptions.Compiled | RegexOptions.IgnoreCase);
	Regex rgx2 = new Regex(pattern2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
	// Apply the 2 regexes
	str = rgx1.Replace(rgx2.Replace(str, ""), "");
