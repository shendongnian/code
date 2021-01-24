    var sentenceA = "Sentence A";
    var sentenceB = "Sentence B";
    using (var output = System.IO.File.Create("output"))
    {
        foreach (var file in new[] { "file1", "file2" })
        {
            using (var input = File.OpenRead(file))
            {
    			var reader = new System.IO.StreamReader(input);
    			var text = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToString();
    			if (text.Contains(sentenceA) && text.Contains(sentenceB)) {
    				output.Write(text.Substring(text.IndexOf(sentenceA), text.IndexOf(sentenceB) + sentenceB.Length));
    			}
            }
        }
    }
