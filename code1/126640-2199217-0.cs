                        nodes.Sort((node1, node2) =>
                            {
                                if (node1.Label.Equals(node2.Label))
                                {
                                    return 0;
                                }
                                if (node1.Label == "Favorites" || node1.Label == "Recent")
                                    {
                                        return Int32.MinValue;
                                    }
                                if (node2.Label == "Favorites" || node2.Label == "Recent")
                                {
                                    return Int32.MaxValue;
                                }
                                return node1.Label.CompareTo(node2.Label);
                             });  
