    namespace ConsoleApplication1
    {
        using System.Diagnostics;
        using System.Windows.Forms;
    
        class Program
        {
            static void Main( string[] args )
            {
                var docName = @"some.doc";
    
                try
                {
                    using ( var proc = new Process() )
                    {
                        proc.StartInfo.UseShellExecute = true;
    
                        proc.StartInfo.FileName = docName;
    
                        proc.Start();
                    }
                }
                catch ( System.Exception ex )
                {
                    MessageBox.Show( string.Format( "Unable to display document '{0}': {1}", docName, ex.Message ) );
                }
            }
    
        }
    }
