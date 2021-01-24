                        foreach (var e in run.Elements())
                        {
                            if (e.LocalName == "tab")
                            {
                                Console.WriteLine("    Element Tab: " + e.InnerText.ToString());
                                s = s + " ";
                            }
                            else if (e.LocalName == "t")
                            {
                                Console.WriteLine("    Element Text: " + e.InnerText.ToString());
                                s = s + e.InnerText.ToString();
                            }
                            else
                            {
                                Console.WriteLine("Drop Through RUN set: " + e.LocalName);
                            }
                        }
