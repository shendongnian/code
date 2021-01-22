    void DirSearch(string sDir) {
	try	
	{
	   foreach (string d in Directory.GetDirectories(sDir)) 
	   {
		foreach (string f in Directory.GetFiles(d, txtFile.Text)) 
		{
		   lstFilesFound.Items.Add(f);
		}
		DirSearch(d); /// Recursive Call !!
	   }
	}
	catch (System.Exception excpt) 
	{
		Console.WriteLine(excpt.Message);
	}}
