      string path = "c:\\Item.dat";
    
                if (!File.Exists(path))
                {
                    Console.WriteLine("Item.dat path is not well!");
                }
    
                string allText = File.ReadAllText(path);
                string[] blocks = allText.Split(new string[] { "#========================================================" }, StringSplitOptions.None);
                foreach (string block in blocks)
                {
                    string s = blocks[0];
                    string[] fields = Regex.Split(s, "\r");
                    foreach (string field in fields)
                    {
                        if (field != "~")
                        {
                            string[] values = Regex.Split(field, "\t");
                            foreach (var value in values)
                            {
                               
                            }
                            Console.Write("\n");
                        }
                        else
                        {
                            Console.Write("Entire document parsed");
                        }
                    }
                    Console.WriteLine("Item parsed\n");
                }
                Console.Write("Entire document parsed");
