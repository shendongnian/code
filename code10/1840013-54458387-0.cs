	using System;
	using System.IO;
	
	// Based on an example from Microsoft: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
	class Program
	{
		static void Main(string[] args)
		{
			string delimitor = ",";
			
			// Create a string array with the lines of text
			string[] lines = 
			{ 
				$"Data recorded on date{delimitor}The parameters of this Test Sequence were set to{delimitor}X{delimitor}Key Orientation", // columnn titles
				$"data record 1{delimitor}data record 2{delimitor}data record 2{delimitor}", // First data line
				$"data record 1{delimitor}data record 2{delimitor}data record 2{delimitor}", // Second data line
				$"data record 1{delimitor}data record 2{delimitor}data record 2{delimitor}"  // Third data line
			};
			
		
			var filename = "Resultfile_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
			
			// Set a variable to the Documents path.
			string docPath =
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		
			// Write the string array to a new file named "WriteLines.txt".
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, filename)))
			{
				foreach (string line in lines)
					outputFile.WriteLine(line);
			}
		}
	}
