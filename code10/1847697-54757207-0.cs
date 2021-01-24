    public class Test{
    	public static void Main(){
    		disminuyeCasiller(new[] { "111555"}, new[] { "RT0102"}, new[] {100.50});
    	}
    
    	public static void disminuyeCasiller(string[] codParte, string[] rolls, double[] cantResta)
    	{
    		int size = codParte.Length;
    
    		for (int i = 0; i < size; i++)
    		{
    			string parte = codParte[i];
    			string rol = rolls[i];
    			double valorRes = cantResta[i];
    			Console.WriteLine($"parte {parte}/rol {rol}/valorRes {valorRes}"); //Result:parte 111555/rol RT0102/valorRes 100.5
    		}
    	}
    }
