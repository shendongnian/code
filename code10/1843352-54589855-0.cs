	using System;
	namespace ConsoleTest
	{
		class Program
		{
			static void Main(string[] args)
			{
				int TotalValue = 250; // Total Item Example
				int TotalExecution = 0;
				bool Finish_Status = false;
				Console.Write("Progression Info\n             Total Item : \n             Execution Total : \n             Remaining : \n             Finish_Status : ");
				for (int i = 0; i < TotalValue; ++i)
				{
					//Do Work Here
					System.Threading.Thread.Sleep(10); // Example Work
					TotalExecution++;
					if (TotalValue - TotalExecution == 0)
					{
						Finish_Status = true;
					}
					Console.SetCursorPosition(26, 1);
					Console.Write(TotalValue);
					Console.SetCursorPosition(31, 2);
					Console.Write(TotalExecution);
					Console.SetCursorPosition(25, 3);
					Console.Write(TotalValue - TotalExecution);
					Console.SetCursorPosition(29, 4);
					Console.Write(Finish_Status);
				}
				Console.ReadLine();
			}
		}
	}
