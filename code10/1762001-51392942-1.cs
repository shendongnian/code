    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<Bill> bills = new List<Bill>();
    		bills.Add(new Bill() {ActualAmount = 150, PaidAmount = null});
    		bills.Add(new Bill() {ActualAmount = 150, PaidAmount = null});
    		// bills.Add(new Bill() {ActualAmount = 2400, PaidAmount = 2000});
    		bills.Add(new Bill() {ActualAmount = 2400, PaidAmount = 400});
    		
    		var amount = bills.Sum(x => (x.ActualAmount - (x.PaidAmount ?? 0)));
    		Console.WriteLine(amount);
    	}
    }
    
    public class Bill
    {
    	public double? ActualAmount {get; set;}
    	public double? PaidAmount {get; set;}
    }
