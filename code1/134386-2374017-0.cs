        DirectoryInfo di = new DirectoryInfo("c:/temp/");
        FileInfo[] rgFiles = di.GetFiles("somepicture.*");
        foreach (FileInfo fi in rgFiles)
        {
            if(fi.Name.Contains("."))
            {
                string name = fi.Name.Split('.')[0].ToString();
                string ext =  fi.Name.Split('.')[1].ToString();
                System.Console.WriteLine("Extension is: " + ext);
            }
        }
