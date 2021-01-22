    private string StripInput(string input)
        {
            var output = input
                .Replace(" ", "_")
                .ToLower().Trim();
            return output;
        }
    
    string TEST = "Hello World";
        litTest.Text = StripInput(TEST);
