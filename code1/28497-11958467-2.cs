    //based off of code at http://support.microsoft.com/kb/932491
    using System.Data;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System;
    public class GenerateSomeDataTableErrors
    {	
    	public static void Main()
    	{
    		DataTable Table = new DataTable("Employee");
    		Table.Columns.Add("Id", typeof(int));
    		Table.Columns.Add("Name", typeof(string));
    		Table.PrimaryKey = new DataColumn[] { Table.Columns["Id"] };
    		
    		DataSet Employees = new DataSet();
    		Employees.Tables.Add(Table);
    
    		DataRow ManagerB = Table.NewRow();
    		ManagerB["ID"] = 392;
    		ManagerB["Name"] = "somename";
    		Table.Rows.Add(ManagerB);
    
    		DataRow ManagerA = Table.NewRow();
    		ManagerA["ID"] = 394;
    		ManagerA["Name"] = "somename";
    		Table.Rows.Add(ManagerA);
    
    		Employees.AcceptChanges();
    
    		object locker = new object();
    
    		//key = exception string, value = count of exceptions with same text
    		ConcurrentDictionary<string, int> exceptions = new ConcurrentDictionary<string, int>();
    		
    		DataView employeeNameView = new DataView(Table, string.Empty, "Name", DataViewRowState.CurrentRows);
    
    		Parallel.For(0, 100000, (i, s) =>
    		{
    			try
    			{
    				#region do modifications to the table, in a thread-safe fashion
					lock (locker)
					{
						var row = Table.Rows.Find(392);
						if (row != null) //it's there, delete it
						{
							row.Delete();
							Employees.AcceptChanges();
						}
						else //it's not there, add it
						{
							var newRow = Table.NewRow();
							newRow["ID"] = 392;
							newRow["Name"] = "somename";
							Table.Rows.Add(newRow);
							Employees.AcceptChanges();
						}
					}
					#endregion
    
    				//Apparently this is the dangerous part, finding rows 
    				// without locking on the same object the modification work is using.
					//lock(locker)
    				employeeNameView.FindRows("somename");
    			}
    			catch (Exception e)
    			{
    				string estring = e.ToString();
    				exceptions.TryAdd(estring, 0);
    				lock (exceptions)
    				{ exceptions[estring] += 1; }
    			}
    		});
    
    		foreach (var entry in exceptions)
    		{
    			Console.WriteLine("==============The following occurred " + entry.Value + " times");
    			Console.WriteLine(entry.Key);
    		}
    	}//Main
    }//class
