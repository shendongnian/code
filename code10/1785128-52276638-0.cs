    public class ZeilenLesen
    {
    	public static string path1 = @"C:\temp\02\";
    
    	public static void ReadLine()
    	{
    		try
    		{
    			var files = from file in Directory.GetFiles(path1, "Deploytest.txt", SearchOption.AllDirectories)
    				from line in File.ReadLines(file)
    				where line.Contains("]appName")
    				select new
    				{
    					File = file,
    					Line = line
    				};
    
    			foreach (var app in files)
    			{
    				Console.WriteLine("{0}", app.Line);
    				if (app.Line != "[string]appName = AAA")
    				{
    					Console.WriteLine("appname not the same");
    					Console.ReadLine();
    				}
    				else
    				{
    					Console.WriteLine ("appname is okay");
    				}
    			}
    			Console.WriteLine("{0} files found.", files.Count().ToString());
    		}
    		catch (UnauthorizedAccessException UAEx) //Die Ausnahme, die ausgelöst wird, wenn das Betriebssystem aufgrund eines E/A-Fehlers oder eines bestimmten Typs von Sicherheitsfehler den Zugriff verweigert.
    		{
    		    Console.WriteLine(UAEx.Message);
    		}
    	}
    }
