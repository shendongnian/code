    var preambles = new Dictionary<string, byte[]>();
    foreach (var encodingInfo in Encoding.GetEncodings()) {
    	Encoding encoding = Encoding.GetEncoding(encodingInfo.Name);
    	var preamble = encoding.GetPreamble();
    	if (preamble != null && preamble.Length > 0)
    		preambles.Add(encodingInfo.Name, preamble);
    }
