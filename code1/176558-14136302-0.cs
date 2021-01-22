     for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox2.Items.Contains(ListBox1.Items[i]))
                    {
                            ListBox1.Items.RemoveAt(i);
                            i--;
                    }
                }
