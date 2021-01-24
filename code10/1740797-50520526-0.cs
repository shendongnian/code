    namespace EditWordDotSO
    {
        class Program
        {
            static void Main(string[] args)
            {
                var applicationWord = new Microsoft.Office.Interop.Word.Application();
                applicationWord.Visible = true;
    
                Document dot = new Document();
    
                try
                {
                    dot = applicationWord.Documents.Open(@"path\to\your\a.dotx");
                    dot.Activate();
                }
                catch (COMException ex)
                {
                    Console.Write(ex);
                    dot.Application.Quit();
                }
                finally
                {
                    dot?.Application?.Quit();
                }
            }
        }
    }
