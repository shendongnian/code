	private void buttonGravaPass_Click(object sender, EventArgs e)
	{
		var lines = ModifyLines(File.ReadLines(dirConta));
		File.WriteAllLines(dirConta, lines.ToArray());
	}
