        public void Run1()
    {
        Console.WriteLine("Reading OCR path from registry");
        string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Tomcat\Common";
        string valueName = "OCR_path";
        string OCRPath = Microsoft.Win32.Registry.GetValue(keyName, valueName, null) as string;
        if (string.IsNullOrWhiteSpace(OCRPath))
        {
            string text = "3";
            System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\OCR-Toolkit-Check.txt", text);
        }
    }
