		string binary = "011001010101000100101";
		var codes = new Dictionary<string, string> {
			{"00", "A"},
			{"01", "C"},
			{"10", "G"},
			{"11", "T"}
		};
		
		StringBuilder builder = new StringBuilder();
		
		for(int i = 0; i + 1 < binary.Length; i = i + 2) {
			var localCode = string.Format("{0}{1}", binary[i], binary[i+1]);
			string buffer;
			var output = codes.TryGetValue(localCode, out buffer) ? buffer : string.Empty;
			builder.Append(output);
		}
		
		string result = builder.ToString();
