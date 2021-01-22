    public partial class Program
	{
		[DllImport("msvcrt", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
		public static extern int rename(
				[MarshalAs(UnmanagedType.LPStr)]
				string oldpath,
				[MarshalAs(UnmanagedType.LPStr)]
				string newpath);
		static void FileRename()
		{
			while (true)
			{
				Console.Clear();
				Console.Write("Enter a folder name: ");
				string dir = Console.ReadLine().Trim('\\') + "\\";
				if (string.IsNullOrWhiteSpace(dir))
					break;
				if (!Directory.Exists(dir))
				{
					Console.WriteLine("{0} does not exist", dir);
					continue;
				}
				string[] files = Directory.GetFiles(dir, "*.mp3");
				for (int i = 0; i < files.Length; i++)
				{
					string oldName = Path.GetFileName(files[i]);
					int pos = oldName.IndexOfAny(new char[] { '0', '1', '2' });
					if (pos == 0)
						continue;
					string newName = oldName.Substring(pos);
					int res = rename(files[i], dir + newName);
				}
			}
			Console.WriteLine("\n\t\tPress any key to go to main menu\n");
			Console.ReadKey(true);
		}
	}
