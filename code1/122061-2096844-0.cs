    sqldatapull = dr[0].ToString();
                    if (sqldatapull.StartsWith("OBJECT"))
                    {
                        sqldatapull = "";
                    }
                    listBox1.Items.Add(sqldatapull);
                    for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                    {
                        if (String.IsNullOrEmpty(listBox1.Items[i] as String))
                            listBox1.Items.RemoveAt(i);
                    }
                }
