    string s = "Hello World I am on stack overflow";
                string AfterWord = string.Empty;
                if (s.Length > 0)
                {
                    int i = s.IndexOf(" ") + 1;
                    AfterWord = s.Substring(i);
                  
                }
