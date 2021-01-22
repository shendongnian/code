        private void AutoSizeColumnList(ListView listView)
		{
            //Prevents flickering
			listView.BeginUpdate();
			Dictionary<int, int> columnSize = new Dictionary<int,int>();
			//Auto size using header
			listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			//Grab column size based on header
			foreach(ColumnHeader colHeader in listView.Columns )
				columnSize.Add(colHeader.Index, colHeader.Width);
			//Auto size using data
			listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			
			//Grab comumn size based on data and set max width
			foreach (ColumnHeader colHeader in listView.Columns)
			{
				int nColWidth;
				if (columnSize.TryGetValue(colHeader.Index, out nColWidth))
					colHeader.Width = Math.Max(nColWidth, colHeader.Width);
                else
                    //Default to 50
                    colHeader.Width = Math.Max(50, colHeader.Width);
			}
			listView.EndUpdate();
		}
