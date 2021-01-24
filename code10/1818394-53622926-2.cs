    try
	{
        // will open or create file in 'append' mode
		using (var outputFile = new StreamWriter("test.txt", true))
		{
			outputFile.Write($"{numberOfStudents}, {studentName}, {studentHeight},{studentWeight}");
			outputFile.Write(Environment.NewLine);
		}
		using (BinaryWriter databaseFile = new BinaryWriter(File.Open("outFile.bin", FileMode.Append)))
		{                                 
			databaseFile.Write(studentName + " " + studentHeight + " " + studentWeight);
		}
	}
	catch (System.IO.IOException exc)
	{
		Console.WriteLine("There was an error!: " + exc.Message);
	}
