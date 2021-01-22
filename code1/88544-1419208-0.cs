    string filename = "instruction.txt";
    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@filename);
     
    System.Diagnostics.Process rfp = new System.Diagnostics.Process();
    rfp = System.Diagnostics.Process.Start(psi);
     
    rfp.WaitForExit(2000);
     
    if (rfp.HasExited)
    {
       System.IO.File.Delete(filename);
    }
     
    //execute other code after the program has closed
    MessageBox.ShowDialog("The program is done.");
