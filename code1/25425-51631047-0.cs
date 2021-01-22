    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    internal static class MeasureTime
    {
    	internal static TimeSpan Run(Action func, uint count = 1)
    	{
    		if (count == 0)
    		{
    			throw new ArgumentOutOfRangeException("count", "Must be greater than zero");
    		}
    
    		long[] arr_time = new long[count];
    		Stopwatch sw = new Stopwatch();
    		for (uint i = 0; i < count; i++)
    		{
    			sw.Start();
    			func();
    			sw.Stop();
    			arr_time[i] = sw.ElapsedTicks;
    			sw.Reset();
    		}
    
    		return new TimeSpan(count == 1 ? arr_time.Sum() : Convert.ToInt64(Math.Round(arr_time.Sum() / (double)count)));
    	}
    }
    
    public class Program
    {
    	public static string RandomString(int length)
    	{
    		Random random = new Random();
    		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    		return new String(Enumerable.Range(1, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
    	}
    
    	public static void Main()
    	{
    		string rnd_str = RandomString(500000);
    		Regex regex = new Regex("a|c|e|g|i|k", RegexOptions.Compiled);
    		TimeSpan ts1 = MeasureTime.Run(() => regex.Replace(rnd_str, "!!!"), 10);
    		Console.WriteLine("Regex time: {0:hh\\:mm\\:ss\\:fff}", ts1);
    		
    		StringBuilder sb_str = new StringBuilder(rnd_str);
    		TimeSpan ts2 = MeasureTime.Run(() => sb_str.Replace("a", "").Replace("c", "").Replace("e", "").Replace("g", "").Replace("i", "").Replace("k", ""), 10);
    		Console.WriteLine("StringBuilder time: {0:hh\\:mm\\:ss\\:fff}", ts2);
    		
    		TimeSpan ts3 = MeasureTime.Run(() => rnd_str.Replace("a", "").Replace("c", "").Replace("e", "").Replace("g", "").Replace("i", "").Replace("k", ""), 10);
    		Console.WriteLine("String time: {0:hh\\:mm\\:ss\\:fff}", ts3);
    	}
    }
