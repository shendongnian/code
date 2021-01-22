    WriteResourceToFile("Project_Namespace.Resources.filename_as_in_resources.extension", "extractedfile.txt");
    public static void WriteResourceToFile(string resourceName, string fileName)
    {
        int bufferSize = 4096; // set 4KB buffer
        byte[] buffer = new byte[bufferSize];
        using (Stream input = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        using (Stream output = new FileStream(fileName, FileMode.Create))
        {
            int byteCount = input.Read(buffer, 0, bufferSize);
            while (byteCount > 0)
            {
                output.Write(buffer, 0, byteCount);
                byteCount = input.Read(buffer, 0, bufferSize);
            }
        }
    }
