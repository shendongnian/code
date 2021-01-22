    public void ReadRessourceFile()
    {
    	//Requires Assembly System.Windows.Forms '
    	System.Resources.ResXResourceReader rsxr = new System.Resources.ResXResourceReader("items.resx");
    
    	// Iterate through the resources and display the contents to the console. '    
    	System.Collections.DictionaryEntry d = default(System.Collections.DictionaryEntry);
    	foreach (DictionaryEntry d_loopVariable in rsxr) {
    		d = d_loopVariable;
    		Console.WriteLine(d.Key.ToString() + ":" + ControlChars.Tab + d.Value.ToString());
    	}
    
    	//Close the reader. '
    	rsxr.Close();
    }
