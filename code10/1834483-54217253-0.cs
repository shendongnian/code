    bool check = false;
                string result = string.Empty;
                string myName = "John Smith";
                //note the space, this is intentional, as whether there is a space after the comma is inconsistent
                var myOptions = new List<string> { "Smith,John", "Doe, Bob" };
                var myKeywords = myName.Split(' ').ToList();
    
                foreach(string s in myOptions)
                {
                    if (myKeywords.All(s.Contains))
                    {
                        check = true;
                    }
                }
