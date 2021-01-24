		   string keeplineoflongestfrag="";
		   string stlongestfrag="";
           int longestfrag = 0;
           
           using (StreamReader file = new StreamReader((filepath, System.Text.Encoding.Default))
            {
                string line;
                char[] space = { ' ' };
                while ((line = file.ReadLine()) != null)
                {
                    var wordsWithSeparators = lines.Split(space, StringSplitOptions.RemoveEmptyEntries);
                    bool modify = false
					foreach(var lg in wordsWithSeparators)
					{
						if (lg.Length > longestfrag)
						{
							longestfrag = lg.Length;
							stlongestfrag = lg;
							if (!modify)
							{
								keeplineoflongestfrag= line ;
								modify = true;
							}
						}
					}
                }
            }
