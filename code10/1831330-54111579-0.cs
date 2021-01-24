	       public List<string> myValues= new List<string>();
            int count = xtlItemList.Nodes.Count; // number of nodes in three
			for (int i = 0; i < count; i++)
			{
				var columnID1 = xtlItemList.Columns[2]; // get the column with index of 2
				var cellValue = xtlItemList.Nodes[i][columnID1]; // get value
				myStrings.Add(cellValue.ToString()); // save value
			}
            // change sort order
			xtlItemList.BeginSort();
			xtlItemList.Columns[2].SortOrder = SortOrder.None;
			xtlItemList.EndSort();
            // return the values
			for (int i = 0; i < myStrings.Count; i++)
			{
				var columnID1 = xtlItemList.Columns[2];
				xtlItemList.Nodes[i].SetValue(columnID1, myStrings[i]);
			}
