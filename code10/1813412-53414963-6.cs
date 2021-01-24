    private void HexBox_CopiedHex(object sender, EventArgs e)
    {
    	var hex = Clipboard.GetText();
    	using (var writer = new StreamWriter(@"C:\00_Work\test.bin"))
    	{
    		writer.Write(hex);
    	}
    }
