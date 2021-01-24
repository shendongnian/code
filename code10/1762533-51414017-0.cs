	private Random rnd = new Random();
	
    public int rand_num()
    {
		string exe_path = System.Windows.Forms.Application.ExecutablePath;
		string exe_folder = System.IO.Path.GetDirectoryName(exe_path);
		string file_path = System.IO.Path.Combine(exe_folder, "Invoices\numbers.txt");
			
		var number =
			Enumerable
				.Range(0, 10000)
				.Except(File.ReadAllLines(file_path).Select(x => int.Parse(x)))
				.OrderBy(x => rnd.Next())
				.First();
		
		File.AppendAllLines(file_path, new [] { number.ToString() });
		
		return number;
    }
