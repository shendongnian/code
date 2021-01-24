    using System;
						
	public class Program
	{
		public static void Main()
		{
				string consoleOutput = @"
					25.5.2018 10:42:35.621 Status message 0884:Running module SamplesSim.
				
					25.5.2018 10:42:35.621 Status message 0120:Data Input: Opening: T:\RCS\BiggieStatementsOn\PRINT\INPUTJACK\FCA_HomeBandAccounts_23052018.csv. (DataInput1)
				";
				string wordToFind = "Running module";
				var startIndex = consoleOutput.IndexOf(wordToFind);
				string[] ModuleParams;
				string runningMod = "";
				
				if (startIndex != -1)
				{
					var lastIndex = startIndex + wordToFind.Length;
					if (lastIndex != -1)
					{
						ModuleParams = consoleOutput
										   .Substring(startIndex+wordToFind.Length, consoleOutput.Length - (startIndex+wordToFind.Length))
							.Split(new char[]{' ','\n','.'}, StringSplitOptions.RemoveEmptyEntries);
				
						runningMod = ModuleParams[0];
									 //.Substring(4).Replace("Running module", "").Trim();
					}                                
					Console.WriteLine(runningMod);
				}
		}
	}
