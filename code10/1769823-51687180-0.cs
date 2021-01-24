    namespace MSWordReplacement
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application app = new Application();
                Document doc = app.Documents.Open(@"C:\Sample.docx");
    
                // Assign a search string to a variable.
                object findText = "Find me.";
    
                // Clear formatting from previous searches.
                app.Selection.Find.ClearFormatting();
                
                if (app.Selection.Find.Execute(ref findText))
                {
                    // Replace new text.
                    app.Selection.Text = "You found me!";
                }
                else
                {
                    // Do somthing else.
                }
    
                doc.Close(true);
                app.Quit();
            }
        }
    }
