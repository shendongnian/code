		public void DebugTable(DataTable table)
		{
			Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
			int zeilen = table.Rows.Count;
			int spalten = table.Columns.Count;
			// Header
			for (int i = 0; i < table.Columns.Count; i++)
			{
				string s = table.Columns[i].ToString();
				Debug.Write(String.Format("{0,-20} | ", s));
			}
			Debug.Write(Environment.NewLine);
			for (int i = 0; i < table.Columns.Count; i++)
			{
				Debug.Write("---------------------|-");
			}
			Debug.Write(Environment.NewLine);
			// Data
			for (int i = 0; i < zeilen; i++)
			{
				DataRow row = table.Rows[i];
				//Debug.WriteLine("{0} {1} ", row[0], row[1]);
				for (int j = 0; j < spalten; j++)
				{
					string s = row[j].ToString();
					if (s.Length > 20) s = s.Substring(0, 17) + "...";
					Debug.Write(String.Format("{0,-20} | ", s));
				}
				Debug.Write(Environment.NewLine);
			}
			for (int i = 0; i < table.Columns.Count; i++)
			{
				Debug.Write("---------------------|-");
			}
			Debug.Write(Environment.NewLine);
		}
