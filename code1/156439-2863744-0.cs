    try
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.UseShellExecute = false;
        psi.FileName = pathToExe;
        Process.Start(psi);
    }
    catch (Win32Exception ex)
    {
        if (ex.NativeErrorCode == 0xc1)
        {
            Console.WriteLine("Not a valid executable.");
        }
        else
        {
            throw;
        }
    }
