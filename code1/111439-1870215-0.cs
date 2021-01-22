                string[] data = new string[] {
                "Item1 Item1Desc Project1 RoomE Closet-7",
                "Item2 Item2Desc Project1 RoomW Closet8",
                "Item3 Item3Desc Project1 RoomW Closet8",
                "Item4 Item4Desc Project1 RoomN Closet2",
                "Item5 Item5Desc Project1 RoomN Closet9",
                "Item6 Item6Desc Project2 RoomN Closet2",
                "Item7 Item7Desc Project2 RoomW Closet9" };
            foreach (string row in data)
            {
                string[] columns = row.Split(' ');
                TreeNodeCollection treeNodes=treeView1.Nodes;
                for (int col = 2; col < columns.Length; col++)
                {
                    string column = columns[col];
                    if (!treeNodes.ContainsKey(column))
                    {
                        treeNodes.Add(column, column);
                    }
                    TreeNode tn = treeNodes[column];
                    treeNodes = tn.Nodes;
                }
                treeNodes.Add(string.Format("{0} - {1}", columns[0], columns[1]));
            }
