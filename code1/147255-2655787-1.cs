            string myStr = "{0}{1}{2}";
            string[] strArgs = new string[]{"this", "that"};
            string result = null;
            
            try { result = string.Format(myStr, strArgs); }
            
            catch (FormatException fex)
            {
                if (fex.Message.StartsWith("Input"))
                    Console.WriteLine
                      ("Trouble with format string: \"" + myStr + "\"");
                else
                    Console.WriteLine
                      ("Trouble with format args: " + string.Join(";", strArgs));
                Regex reg = new Regex(regex, RegexOptions.Multiline);
                MatchCollection matches = reg.Matches(myStr);
                Console.WriteLine
                    ("Your format has {0} tokens and {1} arguments", 
                     matches.Count, strArgs.Length );
            }
