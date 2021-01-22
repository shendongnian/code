    [STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		if(...condition...)
        {
			Application.Run(new Form1());
		}
		else
		{
			Application.Run(new Form2());
		}
	}
