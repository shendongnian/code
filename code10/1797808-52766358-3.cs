    using System;
    using System.Linq;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string dirToExamine = @"C:\temp\testDirs";
    
    			/* Get the directories which start with six digits */
    			var re = new Regex("^[0-9]{6}");
    			var dirs = new DirectoryInfo(dirToExamine).GetDirectories()
    				.Where(d => re.IsMatch(d.Name))
    				.ToList();
    
    			/* The directory names start MMyyyy but we want them ordered by yyyyMM */
    			var withDates = dirs.Select(d => new
    			{
    				Name = d,
    				YearMonth = d.Name.Substring(2, 4) + d.Name.Substring(0, 2)
    			})
    				.OrderByDescending(f => f.YearMonth, StringComparer.OrdinalIgnoreCase)
    				.Select(g => g.Name).ToList();
    
    			Console.WriteLine(string.Join("\r\n", withDates));
    			Console.ReadLine();
    
    		}
    	}
    }
