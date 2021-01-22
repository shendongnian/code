		Regex rgx = new Regex("{([Dd]:([^{]+))}");
		private string GenerateTrueFilename()
		{
			// Figure out the new file name
			string lfn = LogFileName;
			while (rgx.IsMatch(lfn))
			{
				Match m = rgx.Matches(lfn)[0];
				string tm = m.Groups[1].Value;
				if (tm.StartsWith("D:"))
				{
					string sm = m.Groups[2].Value;
					string dts = DateTime.Now.ToString(sm);
					lfn = lfn.Replace(m.Groups[0].Value, dts);
				}
			}
			return lfn;
		}
