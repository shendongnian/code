        [System.Runtime.InteropServices.DllImport("ole32.dll")]
        static extern void CoFreeUnusedLibraries();
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (axAcroPDF1 != null)
            {                                
                axAcroPDF1.Dispose();                
                System.Windows.Forms.Application.DoEvents();
                CoFreeUnusedLibraries(); 
            }
        }
