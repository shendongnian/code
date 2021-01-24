    var text = inputText.GetComponent<TMP_Text>().text.ToLower();
    var reader = new System.IO.StringReader (text);
    string line;
	while ((line = reader.ReadLine()) != null) {
        switch (line.Trim()) {
        case "спрятан_фрукт()​":
            ...
        }
	}
