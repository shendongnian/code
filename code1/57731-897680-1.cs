    using Microsoft.Win32;
        
    // Check whether Microsoft Word is installed on this computer,
    // by searching the HKEY_CLASSES_ROOT\Word.Application key.
    using (var regWord = Registry.ClassesRoot.OpenSubKey("Word.Application"))
    {
        if (regWord == null)
        {
            Console.WriteLine("Microsoft Word is not installed");
        }
        else
        {
            Console.WriteLine("Microsoft Word is installed");
        }
    }
