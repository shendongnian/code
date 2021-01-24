    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		
    		List<Partner> partenrs=new List<Partner>();
    		partenrs.Add(new Partner(){Name="A"});
    		partenrs.Add(new Partner(){Name="B"});
    		partenrs.Add(new Partner(){Name="C"});
    		partenrs.Add(new Partner(){Name="D"});
    		partenrs.Add(new Partner(){Name="E"});
    		partenrs.Add(new Partner(){Name="F"});
    		
    		var obser=new ObservableCollection<Partner>(partenrs);
    		
    		obser.Move(0,5);
    		foreach(var x in obser)
    		{
    			Console.WriteLine(x.Name);
    		}
    	}
    }
    
    class Partner
    {
    	public string Name{get;set;}
    }
    
