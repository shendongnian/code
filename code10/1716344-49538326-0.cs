    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var lstOcc = new List<Objet>{
    			new Objet
    			{
    				lstcrit = new List<crit>
    				{
    					new crit{ValeurCrit = "one"}, 
    					new crit{ValeurCrit = "two"}, 
    					new crit{ValeurCrit = ""}, 
    					new crit{ValeurCrit = "three"}, 
    					new crit{ValeurCrit = ""}
    				}
    			}, 
    			new Objet{
    				lstcrit = new List<crit>
    				{
    					new crit{ValeurCrit = ""}, 
    						new crit{ValeurCrit = ""}, 
    						new crit{ValeurCrit = ""}, 
    						new crit{ValeurCrit = "two"}, 
    						new crit{ValeurCrit = "four"}}}};
    		var res = lstOcc.Select(o => (double)o.lstcrit.Where(c => c.ValeurCrit.Equals("")).Count() / (double)o.lstcrit.Count());
    		res.ToList().ForEach(r => Console.WriteLine((100*r).ToString("0.00") + "%"));		
    	}
    }
    
    public class Objet
    {
    	public List<crit> lstcrit
    	{
    		get;
    		set;
    	}
    }
    
    public class crit
    {
    	public string ValeurCrit
    	{
    		get;
    		set;
    	}
    }
