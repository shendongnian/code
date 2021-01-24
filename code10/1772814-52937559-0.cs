    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    static void Main(string[] args)
    {
        string CurrentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string IconsFolder = args.Length > 0 ? args[0] : Path.Combine(CurrentPath, "icons");
        UpdateFolderIcons(CurrentPath, IconsFolder);
        Console.WriteLine($"Press any key to terminate...");
        Console.ReadKey();
    }
    public static void UpdateFolderIcons(string BaseFolder, string IconsFolder)
    {
        Console.WriteLine($"Current path: {BaseFolder}");
        Console.WriteLine($"Processing...");
        Console.WriteLine();
        List<string> IniFiles = Directory.GetFiles(BaseFolder, "desktop.ini", SearchOption.AllDirectories).ToList();
        if (IniFiles.Count == 0)
        {
            Console.WriteLine($"No files found!");
            return;
        }
        Console.WriteLine($"{IniFiles.Count} Files Found");
        Console.WriteLine("Updating...");
        Console.WriteLine();
        int UpdateCount = 0;
        foreach (string DesktopIni in IniFiles)
        {
            string[] TextLines = File.ReadAllLines(DesktopIni);
            for (int i = 0; i < TextLines.Length; i++)
            {
                if (TextLines[i].Contains("IconResource="))
                {
                    string IconName = Path.GetFileName(TextLines[i].Split('=').Skip(1).First());
                    TextLines[i] = "IconResource=" + Path.Combine(IconsFolder, IconName);
                    File.SetAttributes(DesktopIni, FileAttributes.Archive);
                    File.WriteAllLines(DesktopIni, TextLines);
                    File.SetAttributes(DesktopIni, FileAttributes.Hidden);
                    UpdateCount += 1;
                }
            }
        }
        Console.WriteLine($"{UpdateCount} Files Updated");
        Console.WriteLine();
    }
