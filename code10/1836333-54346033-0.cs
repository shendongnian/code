    object word;
    Word.Document _activeDocument;
    
			try
			{
				word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
				//If there is a running Word instance, it gets saved into the word variable
			}
			catch (Exception ex)
			{
				//If there is no running instance, it creates a new one
				Type type = Type.GetTypeFromProgID("Word.Application");
				word = System.Activator.CreateInstance(type);
			}
			Word.Application oWord = (Word.Application) word;
            _activeDocument = oWord.ActiveDocument
    
