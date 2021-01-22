	Match matchResults = Null;
	Regex paragraphs = new Regex(@"\A(.{0,5}\b)(.{0,11}\b)(.{0,20}\b)+\Z", RegexOptions.Singleline);
	matchResults = paragraphs.Match(subjectString);
	if (matchResults.Success) {
		String line1 = matchResults.Groups[1].Value
		String line2 = matchResults.Groups[2].Value
		Capture line3andup = matchResults.Groups[3].Captures
		// you now need to iterate over line3andup, extracting the lines.
	} else {
		// Match attempt failed
	} 
