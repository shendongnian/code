    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		Dictionary<string, Action<List<Data_Raw>, List<Data_Result>>> rulesDictionary = new Dictionary<string, Action<List<Data_Raw>, List<Data_Result>>>();
    		rulesDictionary.Add("twentyFifty", CTARules.TwentyFiftyMA);
    	}
    }
    
    class Data_Raw
    {
    }
    
    class Data_Result
    {
    }
    
    class CTARules
    {
    	public static void TwentyFiftyMA(List<Data_Raw> myRawData, List<Data_Result> myResultData)
    	{
    	//do stuff
    	}
    
    	public static void TwentyHundredMA(List<Data_Raw> myRawData, List<Data_Result> myResultData)
    	{
    	//do stuff
    	}
    }
