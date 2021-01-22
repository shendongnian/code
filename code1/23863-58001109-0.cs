    void Main()
    {
    	var loopResults = new List<Results>();
    	var exceptionResults = new List<Results>();
    	var totalRuns = 10000;
    	for (var colCount = 1; colCount < 20; colCount++)
    	{
    		using (var conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=master;Integrated Security=True;"))
    		{
    			conn.Open();
    			
    			//create a dummy table where we can control the total columns
    			var columns = String.Join(",",
    				(new int[colCount]).Select((item, i) => $"'{i}' as col{i}")
    			);
    			var sql = $"select {columns} into #dummyTable";
    			var cmd = new SqlCommand(sql,conn);
    			cmd.ExecuteNonQuery();
    			
    			var cmd2 = new SqlCommand("select * from #dummyTable", conn);
    			
    			var reader = cmd2.ExecuteReader();
    			reader.Read();
    
    			Func<Func<IDataRecord, String, Boolean>, List<Results>> test = funcToTest =>
    			{
    				var results = new List<Results>();
    				Random r = new Random();
    				for (var faultRate = 0.1; faultRate <= 0.5; faultRate += 0.1)
    				{
    					Stopwatch stopwatch = new Stopwatch();
    					stopwatch.Start();
    					var faultCount=0;
    					for (var testRun = 0; testRun < totalRuns; testRun++)
    					{
    						if (r.NextDouble() <= faultRate)
    						{
    							faultCount++;
    							if(funcToTest(reader, "colDNE"))
    								throw new ApplicationException("Should have thrown false");
    						}
    						else
    						{
    							for (var col = 0; col < colCount; col++)
    							{
    								if(!funcToTest(reader, $"col{col}"))
    									throw new ApplicationException("Should have thrown true");
    							}
    						}
    					}
    					stopwatch.Stop();
    					results.Add(new UserQuery.Results{
    						ColumnCount = colCount, 
    						TargetNotFoundRate = faultRate,
    						NotFoundRate = faultCount * 1.0f / totalRuns, 
    						TotalTime=stopwatch.Elapsed
    					});
    				}
    				return results;
    			};
    			loopResults.AddRange(test(HasColumnLoop));
    			
    			exceptionResults.AddRange(test(HasColumnException));
    
    		}
    
    	}
    	"Loop".Dump();
    	loopResults.Dump();
    
    	"Exception".Dump();
    	exceptionResults.Dump();
    	
    	var combinedResults = loopResults.Join(exceptionResults,l => l.ResultKey, e=> e.ResultKey, (l, e) => new{ResultKey = l.ResultKey, LoopResult=l.TotalTime, ExceptionResult=e.TotalTime});
    	combinedResults.Dump();
    	combinedResults
    		.Chart(r => r.ResultKey, r => r.LoopResult.Milliseconds * 1.0 / totalRuns, LINQPad.Util.SeriesType.Line)
    		.AddYSeries(r => r.ExceptionResult.Milliseconds * 1.0 / totalRuns, LINQPad.Util.SeriesType.Line)
    		.Dump();
    }
    public static bool HasColumnLoop(IDataRecord dr, string columnName)
    {
    	for (int i = 0; i < dr.FieldCount; i++)
    	{
    		if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
    			return true;
    	}
    	return false;
    }
    
    public static bool HasColumnException(IDataRecord r, string columnName)
    {
    	try
    	{
    		return r.GetOrdinal(columnName) >= 0;
    	}
    	catch (IndexOutOfRangeException)
    	{
    		return false;
    	}
    }
    
    public class Results
    {
    	public double NotFoundRate { get; set; }
    	public double TargetNotFoundRate { get; set; }
    	public int ColumnCount { get; set; }
    	public double ResultKey {get => ColumnCount + TargetNotFoundRate;}
    	public TimeSpan TotalTime { get; set; }
    	
    	
    }
