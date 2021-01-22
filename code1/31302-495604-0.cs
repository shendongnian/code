    string line;
    string deviceName = string.Empty;
    // Read the file and display it line by line.
    using (System.IO.StreamReader file =
       new System.IO.StreamReader("c:\\file.ini"))
    {
        while ((line = file.ReadLine()) != null)
        {
            if (line.ToLower().StartsWith("devicename"))
            {
                string[] fullName = line.Split('=');
                deviceName = fullName[1];
                break;
            }
        }
    }
    
    Console.WriteLine("Device Name =" + deviceName);
    Console.ReadLine();
