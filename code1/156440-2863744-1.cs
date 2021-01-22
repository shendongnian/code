    const int ERROR_BAD_EXE_FORMAT = 193;
    try
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.UseShellExecute = false;
        psi.FileName = @"C:\tmp\testOLElocal_4.docx";
        Process.Start(psi);
    }
    catch (Win32Exception ex)
    {
        if (ex.NativeErrorCode == ERROR_BAD_EXE_FORMAT)
        {
            // The exception message would be
            // "The specified executable is not a valid application for this OS platform."
            //
            Console.WriteLine("Not a valid executable.");
        }
        else
        {
            throw;
        }
    }
    
