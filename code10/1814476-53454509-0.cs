    using System;
    using System.IO;
    using System.Text;
    class Program
		
	{
		/// <summary>
		/// Static Multidimensional Array what have products quantity.
		/// </summary>
		static int [,] AvailableQuantity = new int[3,4]
		{
		    { 4, 5, 2, 3 },
		    { 2, 7, 3, 4 },
		    { 9, 3, 5, 6 }
		};
		
		/// <summary>
		/// Main Console Call.
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			
			string path = Environment.CurrentDirectory + "\\file.txt";
			
			// TEST
			Purchase_Item(3, 0, 0);
			Purchase_Item(2, 0, 1);
			
			Save_File(path, Generate_String_File());
			
			System.Diagnostics.Process.Start("notepad.exe", path);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		/// <summary>
		/// Edit static int Multidimensional Array. (M.A)
		/// </summary>
		/// <param name="cuantity">The cuantity of the item what has ben purchased.</param>
		/// <param name="row">Row that you want to edit in the M.A.</param>
		/// <param name="column">Column that you want to edit in the M.A.</param>
		private static void Purchase_Item(int cuantity, int row, int column){
			
			try {
				
				if(row > AvailableQuantity.GetLength(0) || row < 0){
					Console.WriteLine("Row - Out of Range");
					return;
				}
				
				if(column > AvailableQuantity.GetLength(1) || column < 0){
					Console.WriteLine("Column - Out of Range");
					return;
				}
				
				int cuantity_in_row = AvailableQuantity[row, column];
				
				if(cuantity > cuantity_in_row){
					Console.WriteLine("Not enough items!");
					return;
				}
				
				AvailableQuantity[row, column] = cuantity_in_row - cuantity;
				
			} catch (Exception eX) {
				
				Console.WriteLine(eX.ToString());
			}
			
		}
		
		/// <summary>
		/// Generate string file, with the format (worst format ever).
		/// </summary>
		/// <returns>text that will be saved.</returns>
		private static string Generate_String_File(){
			
			string line = string.Empty;
			string full_text = string.Empty;
			
			for (int row = 0; row < AvailableQuantity.GetLength(0); row++) {
				
				line = string.Empty;
				
				for (int column = 0; column < AvailableQuantity.GetLength(1); column++) {
					
					line += AvailableQuantity[row, column].ToString() + " ";
				}
				
				line = line.Remove(line.Length-1);
				
				full_text += line + Environment.NewLine;
			}
			
			full_text = full_text.Remove(full_text.Length-1);
			
			return full_text;
		}
		
		/// <summary>
		/// Save the file at the asing path.
		/// </summary>
		/// <param name="path">location where will go the file.</param>
		/// <param name="text">text that will be included at the file.</param>
		private static void Save_File(string path, string text){
			
			try {
				
				File.WriteAllText(path, text);
				
			} catch (Exception eX) {
				
				Console.WriteLine(eX.ToString());
			}
			
			
		}
		
	}
