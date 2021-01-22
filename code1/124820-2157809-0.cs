	StringBuilder sb = new StringBuilder();
	sb.Append("Line 1");
	sb.Append(System.Environment.NewLine); //Change line
	sb.Append("\t"); //Add tabulation
	sb.Append("Line 2");
	using (StreamWriter sw = new StreamWriter("example.txt"))
	{
		sq.Write(sb.ToString());
	}
