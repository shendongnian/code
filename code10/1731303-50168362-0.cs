    using System;
    using System.Data;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Xml;
    					
    public class Program
    {
    	public static void Main()
    	{
    
    		List<double> ValuesA = new List<double>(){0.1,0.2,0.3};
    		List<double> ValuesB = new List<double>(){0.4,0.5,0.6};
    		List<double> ValuesC = new List<double>(){0.7,0.8,0.9};
    		List<double> ValuesD = new List<double>(){1.1,1.2,1.3};
    		
    		var values = new List<object>();
    		values.Add(new { A = ValuesA[0], B = ValuesB[0], C = ValuesC[0], D = ValuesD[0] });
    		values.Add(new { A = ValuesA[1], B = ValuesB[1], C = ValuesC[1], D = ValuesD[1] });
    		values.Add(new { A = ValuesA[2], B = ValuesB[2], C = ValuesC[2], D = ValuesD[2] });
    
    		
    		var jsonString = JsonConvert.SerializeObject(values);
    		//Console.WriteLine(jsonString);
    		
    		
    		var dataTable = JsonConvert.DeserializeObject<DataTable>(jsonString);
    		
    		
    		foreach (DataRow row in dataTable.Rows)
    		{
    			Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", row[0], row[1], row[2], row[3]));
    		}
    	}
    }
