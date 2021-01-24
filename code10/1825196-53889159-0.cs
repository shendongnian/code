			StringBuilder sb = new StringBuilder();
			for (int i = 1; i < 1025; i++)
			{
				sb.Append((char)i);
			}
			string fn = Path.GetTempFileName();
			using (var sw = File.CreateText(fn))
			{
				sw.Write(sb.ToString());
				sw.Flush();
				sw.Close();
			}
			Process.Start(Path.GetDirectoryName(fn));
