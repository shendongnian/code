    Assembly assembly = Assembly.GetExecutingAssembly();
    var input = assembly.GetManifestResourceStream("AssemblyName.Output.xlsx")
    var output = File.Open("output.xlsx");
    CopyStream(input, output);
    public static void CopyStream(Stream input, Stream output)
    {
        byte[] buffer = new byte[32768];
        while (true)
        {
            int read = input.Read (buffer, 0, buffer.Length);
            if (read <= 0)
                return;
            output.Write (buffer, 0, read);
        }
    }
