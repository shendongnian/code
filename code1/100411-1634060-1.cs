            string[] stringArr = {
                                     "Root",
                                     "Root/Item1",
                                     "Root/Item2",
                                     "Root/Item3/SubItem1",
                                     "Root/Item3/SubItem2",
                                     "Root/Item4/SubItem1",
                                     "AnotherRoot"
                                 };
            foreach (string item in stringArr)
            {
                AddItem(treeView1, null, item);
            }
