    [DllImport("kernel32.dll", SetLastError = true)]
    static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess,
    uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition,
    uint dwFlagsAndAttributes, IntPtr hTemplateFile);
    private void Print()
    {
        // Command to be sent to the printer
        string command = "^XA^FO10,10,^AO,30,20^FDFDTesting^FS^FO10,30^BY3^BCN,100,Y,N,N^FDTesting^FS^XZ";
        // Create a buffer with the command
        Byte[] buffer = new byte[command.Length];
        buffer = System.Text.Encoding.ASCII.GetBytes(command);
        // Use the CreateFile external func to connect to the LPT1 port
        SafeFileHandle printer = CreateFile("LPT1:", FileAccess.ReadWrite, 0, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
        // Aqui verifico se a impressora é válida
        if (printer.IsInvalid == true)
        {
            return;
        }
        // Open the filestream to the lpt1 port and send the command
        FileStream lpt1 = new FileStream(printer, FileAccess.ReadWrite);
        lpt1.Write(buffer, 0, buffer.Length);
        // Close the FileStream connection
        lpt1.Close();
    }
