    //I changed newfilename so it's only the filename with extention and not the full path anymore.
    string text = "\"" + oldfilename+ "\"" + " " + "\"" + newfilename;
    
    System.IO.File.WriteAllText(@"c:\test\test.txt", text);
    process.StartInfo.FileName = location;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    result = process.StandardOutput.ReadLine();
