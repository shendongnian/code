        String temp = Console.ReadLine();
		char scale = temp[temp.Length-1];
		if(temp.ToUpper().Contains("F")) {
			int temperature = Int32.Parse(temp.Remove(temp.Length-1,1));
			double celciusValueOfTemp = (temperature-32)/1.8;
			Console.WriteLine(celciusValueOfTemp);
		}
		else if(temp.ToUpper().Contains("C")) {
			int temperature = Int32.Parse(temp.Remove(temp.Length-1,1));
			double fahrenheitValueOfTemp = temperature*1.8+32;
			Console.WriteLine(fahrenheitValueOfTemp);
		}
