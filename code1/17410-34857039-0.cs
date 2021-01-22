                        for (int i = 0; i < result.Length; i++)
                        {
                            // Console.WriteLine(result[i]);
                            if (char.IsUpper(result[i]))
                            {
                                counter++;
                                if (i > 1) //stops from adding a space at if string starts with Capital
                                {
                                    //MessageBox.Show(result[i].ToString());
                                    result = result.Insert(i, " ");
                                    i++; //Required** otherwise stuck in infinite add space loop over a single capital letter.
                                }
                                
                            }
                        }
