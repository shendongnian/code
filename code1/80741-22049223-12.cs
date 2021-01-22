    using System;
    using System.Runtime;
    using System.Diagnostics;
    using System.IO;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Threading;
    
    namespace Algorithm
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			try {
    				int i = 0;
    				int limit = 10;
    				var result = GetTestRandomSort(limit);
    				foreach (var element in result) {
    					Console.WriteLine();
    					Console.WriteLine("time {0}: {1} ms", ++i, element);
    				}
    			} catch (Exception e) {
    				Console.WriteLine(e.Message);
    			} finally {
    				Console.Write("Press any key to continue . . . ");
    				Console.ReadKey(true);
    			}
    		}
    		
    		public static IEnumerable<double> GetTestRandomSort(int limit)
    		{
    			for (int i = 0; i < 5; i++) {
    				string path = null, temp = null;
    				Stopwatch st = null;
    				StreamReader sr = null;
    				int? count = null;
    				List<string> list = null;
    				Random r = null;
    				
    				GC.Collect();
    				GC.WaitForPendingFinalizers();
    				Thread.Sleep(5000);
    
    				st = Stopwatch.StartNew();
    				#region Import Input Data
    				path = Environment.CurrentDirectory + "\\data";
    				list = new List<string>();
    				sr = new StreamReader(path);
    				count = 0;
    				while (count < limit && (temp = sr.ReadLine()) != null) {
    //				    Console.WriteLine(temp);
    					list.Add(temp);
    					count++;
    				}
    				sr.Close();
    				#endregion
    				
    //				Console.WriteLine("--------------Random--------------");
    //				#region Sort by Random with OrderBy(random.Next())
    //				r = new Random();
    //				list = list.OrderBy(l => r.Next()).ToList();
    //				#endregion
    				
    //				#region Sort by Random with OrderBy(Guid)
    //				list = list.OrderBy(l => Guid.NewGuid()).ToList();
    //				#endregion
    				
    //				#region Sort by Random with Parallel and OrderBy(random.Next())
    //				r = new Random();
    //				list = list.AsParallel().OrderBy(l => r.Next()).ToList();
    //				#endregion
    				
    //				#region Sort by Random with Parallel OrderBy(Guid)
    //				list = list.AsParallel().OrderBy(l => Guid.NewGuid()).ToList();
    //				#endregion
    				
    //				#region Sort by Random with User-Defined Shuffle Method
    //				r = new Random();
    //				list = list.Shuffle(r).ToList();
    //				#endregion
    				
    //				#region Sort by Random with Parallel User-Defined Shuffle Method
    //				r = new Random();
    //				list = list.AsParallel().Shuffle(r).ToList();
    //				#endregion
    				
    				// Result
    //				
    				st.Stop();
    				yield return st.Elapsed.TotalMilliseconds;
    				foreach (var element in list) {
					Console.WriteLine(element);
				}
    			}
    
    		}
    	}
    }
Result Description: <img>https://www.dropbox.com/s/9dw9wl259dfs04g/ResultDescription.PNG</img><br/>
Result Stat: <img>https://www.dropbox.com/s/ewq5ybtsvesme4d/ResultStat.PNG</img>
Conclusion:<br/>
Assume: LINQ OrderBy(r.Next()) and OrderBy(Guid.NewGuid()) are not worse than User-Defined Shuffle Method in First Solution.
Answer: They are contradiction.
