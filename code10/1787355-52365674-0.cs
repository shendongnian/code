	public static class Utility
	{
		public const UInt32 SPI_SETMOUSESPEED = 0x0071;
		[DllImport("User32.dll")]
		static extern Boolean SystemParametersInfo(
			UInt32 uiAction,
			UInt32 uiParam,
			UInt32 pvParam,
			UInt32 fWinIni);
		public static void SetMouseSpeed(unit speed)
		{
			for (int i = 0; i < args.Length; i++)
			{
				System.Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
			}
			SystemParametersInfo(
				SPI_SETMOUSESPEED,
				0,
				speed,
				0);
		}
	}
