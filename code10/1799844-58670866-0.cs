		using (StreamReader reader = new StreamReader(filePath))
		{
			using (CsvReader csv = new CsvReader(reader))
			{
				csv.Read();
				Type1 sample = new Type1();
				sample.Id = csv.GetField<int>(0);
				sample.Lines = csv.GetField<int>(1);
				csv.Read();
				Type2 sample2 = new Type2();
				sample2.Angle = csv.GetField<double>(0);
				sample2.Distance = csv.GetField<int>(1);
			}
		}
