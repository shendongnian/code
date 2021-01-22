namespace MyCompany.Util
{
	public class Util
	{
		public static void ReadDictionaryFile()
		{
		}
	}
}
namespace MyCompany.Logging
{
	using MyCompany.Util;
	public class Log
	{
		public void MethodB()
		{
			Util.ReadDictionaryFile();
		}
	}
}
