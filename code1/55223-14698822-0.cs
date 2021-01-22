	public class TestTableBuilder
	{
		public interface ITextRow
		{
			String Output();
			void Output(StringBuilder sb);
			Object Tag { get; set; }
		}
		public class TableBuilder : IEnumerable<ITextRow>
		{
			protected class TextRow : List<String>, ITextRow
			{
				protected TableBuilder owner = null;
				public TextRow(TableBuilder Owner)
				{
					owner = Owner;
					if (owner == null) throw new ArgumentException("Owner");
				}
				public String Output()
				{
					StringBuilder sb = new StringBuilder();
					Output(sb);
					return sb.ToString();
				}
				public void Output(StringBuilder sb)
				{
					sb.AppendFormat(owner.FormatString, this.ToArray());
				}
				public Object Tag { get; set; }
			}
			public String Separator { get; set; }
			protected List<ITextRow> rows = new List<ITextRow>();
			protected List<int> colLength = new List<int>();
			public TableBuilder()
			{
				Separator = "  ";
			}
			public TableBuilder(String separator)
				: this()
			{
				Separator = separator;
			}
			public ITextRow AddRow(params object[] cols)
			{
				TextRow row = new TextRow(this);
				foreach (object o in cols)
				{
					String str = o.ToString().Trim();
					row.Add(str);
					if (colLength.Count >= row.Count)
					{
						int curLength = colLength[row.Count - 1];
						if (str.Length > curLength) colLength[row.Count - 1] = str.Length;
					}
					else
					{
						colLength.Add(str.Length);
					}
				}
				rows.Add(row);
				return row;
			}
			protected String _fmtString = null;
			public String FormatString
			{
				get
				{
					if (_fmtString == null)
					{
						String format = "";
						int i = 0;
						foreach (int len in colLength)
						{
							format += String.Format("{{{0},-{1}}}{2}", i++, len, Separator);
						}
						format += "\r\n";
						_fmtString = format;
					}
					return _fmtString;
				}
			}
			public String Output()
			{
				StringBuilder sb = new StringBuilder();
				foreach (TextRow row in rows)
				{
					row.Output(sb);
				}
				return sb.ToString();
			}
			#region IEnumerable Members
			public IEnumerator<ITextRow> GetEnumerator()
			{
				return rows.GetEnumerator();
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return rows.GetEnumerator();
			}
			#endregion
		}
		static void Main(String[] args)
		{
			TableBuilder tb = new TableBuilder();
			tb.AddRow("When", "ID", "Name");
			tb.AddRow("----", "--", "----");
			tb.AddRow(DateTime.Now, "1", "Name1");
			tb.AddRow(DateTime.Now, "1", "Name2");
			Console.Write(tb.Output());
			Console.WriteLine();
			// or
			
			StringBuilder sb = new StringBuilder();
			int i = 0;
			foreach (ITextRow tr in tb)
			{
				tr.Output(sb);
				if (i++ > 1) sb.AppendLine("more stuff per line");
			}
			Console.Write(sb.ToString());
		}
	}
