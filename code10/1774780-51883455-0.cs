    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Original:");
    		Console.WriteLine(OriginalFindDistinctBeats("STA24,STA24,STA24,STA24,"));
    		Console.WriteLine(OriginalFindDistinctBeats("STA27,STA27,STA27B,STA27A,STA27B,"));
    		
    		Console.WriteLine();
    		
    		Console.WriteLine("New working (removed that weird if statement):");
    		Console.WriteLine(NewFindDistinctBeats("STA24,STA24,STA24,STA24,"));
    		Console.WriteLine(NewFindDistinctBeats("STA27,STA27,STA27B,STA27A,STA27B,"));
    		
    		Console.WriteLine();
    		
    		Console.WriteLine("New working with remove empty:");
    		Console.WriteLine(NewWithRemoveEmptyFindDistinctBeats("STA24,STA24,STA24,STA24,"));
    		Console.WriteLine(NewWithRemoveEmptyFindDistinctBeats("STA27,STA27,STA27B,STA27A,STA27B,"));
    	}
    	
    	public static string OriginalFindDistinctBeats(String Beats)
        // Accept comma-separated string, return distinct values
        {
            string result = string.Empty;
    
            try
            {
                result = string.Join(",", Beats.Split(',').Distinct().ToArray());
                result = result.TrimEnd(',');
    
                if (String.IsNullOrEmpty(result))
                {
                    return result;
                }
                else
                {
                    return result.TrimEnd(result[result.Length - 1]);
                }
    
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    	
    	public static string NewFindDistinctBeats(String Beats)
        // Accept comma-separated string, return distinct values
        {
            string result = string.Empty;
    
            try
            {
                result = string.Join(",", Beats.Split(',').Distinct().ToArray());
                result = result.TrimEnd(',');
    
                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    	
    	public static string NewWithRemoveEmptyFindDistinctBeats(String Beats)
        // Accept comma-separated string, return distinct values
        {
            string result = string.Empty;
    
            try
            {
                result = string.Join(",", Beats.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray());
    
                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
