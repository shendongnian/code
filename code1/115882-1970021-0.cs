    using System.Windows.Forms;
    using System.IO;
        
    TextBox myEditor = new TextBox();
    myEditor.Multiline = true;
    myEditor.ScrollBars = ScrollBars.Vertical;
    myEditor.AcceptsReturn = true;
    myEditor.AcceptsTab = true;
    myEditor.WordWrap = true;
    
    // Get the text from the file.
    	StreamReader sr = new StreamReader("SomeFile.txt"))
    	
    myEditor.Text = sr.ReadToEnd();
