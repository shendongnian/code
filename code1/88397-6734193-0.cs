    	public enum myEnum
	{
		ThisNameWorks,
		ThisNameDoesntWork149141331,// This Name doesn't work
		NeitherDoesThis1849204824// Neither.does.this;
	}
	class Program
	{
		private static unsafe void ChangeString(string original, string replacement)
		{
			if (original.Length < replacement.Length)
				throw new ArgumentException();
			fixed (char* pDst = original)
			fixed (char* pSrc = replacement)
			{
				// Update the length of the original string
				int* lenPtr = (int*)pDst;
				lenPtr[-1] = replacement.Length;
				// Copy the characters
				for (int i = 0; i < replacement.Length; i++)
					pDst[i] = pSrc[i];
			}
		}
		public static unsafe void Initialize()
		{
			ChangeString(myEnum.ThisNameDoesntWork149141331.ToString(), "This Name doesn't work");
			ChangeString(myEnum.NeitherDoesThis1849204824.ToString(), "Neither.does.this");
		}
		static void Main(string[] args)
		{
			Console.WriteLine(myEnum.ThisNameWorks);
			Console.WriteLine(myEnum.ThisNameDoesntWork149141331);
			Console.WriteLine(myEnum.NeitherDoesThis1849204824);
			Initialize();
			Console.WriteLine(myEnum.ThisNameWorks);
			Console.WriteLine(myEnum.ThisNameDoesntWork149141331);
			Console.WriteLine(myEnum.NeitherDoesThis1849204824);
		}
