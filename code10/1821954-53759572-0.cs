                //SQL Result
                string[] yourArray = new string[] { "123", "321", "456" };
                // Empty List for binding datasource.
                IList<string> list = new List<string>();
                // If your result contains 123, adding items to list. 
                if (yourArray.Contains("123"))
                {
                    //Console.WriteLine("Data Found");
                    foreach (string yourArrayItem in yourArray)
                    {
                        list.Add(yourArrayItem);
                    }
                }
                // then adding list to datasource.
                yourBindingSource.DataSource = list;
