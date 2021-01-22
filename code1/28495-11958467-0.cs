    //based off of code at http://support.microsoft.com/kb/932491
    using System.Data;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    		ManagerB["Name"] = "Manager B";
    		Table.Rows.Add(ManagerB);
    
    		Employees.AcceptChanges();
    
    		/////commented to introduce error//////
    		//object locker = new object();
    
    		//instead of failing at the first exception, keep track of those received
    		ConcurrentDictionary<Type, List<Exception>> exceptions = new ConcurrentDictionary<Type, List<Exception>>();
    
    		Parallel.For(0, 1000, (i, s) =>
    		{
    			try
    			{
    				/////commented to introduce error//////
    				//lock (locker)
    				//{
    					var row = Table.Rows.Find(392);
    					
    					//do some modifications to the table
    					if (row != null) //it's there, delete it
    					{
    						row.Delete();
    						Employees.AcceptChanges();
    					}
    					else //it's not there, add it
    					{
    						var newRow = Table.NewRow();
    						newRow["ID"] = 392;
    						newRow["Name"] = "Manager B";
    						Table.Rows.Add(newRow);
    					}
    				/////commented to introduce error//////
    				//}
    			}
    			catch (Exception e)
    			{
    				if(!exceptions.ContainsKey(e.GetType()))
    				{
    					exceptions.TryAdd(e.GetType(), new List<Exception>());
    				}
    				exceptions[e.GetType()].Add(e);
    			}
    		});
    
    		foreach (var entry in exceptions)
    		{
    			Console.WriteLine("==============" + entry.Key.Name + " was thrown " + entry.Value.Count + " times");
    			Console.WriteLine(entry.Value.First()); //print one example of this exception
    		}
    	}//Main
    }//class
