        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (StreamReader sr = new StreamReader(fs))
        {
            while (someCondition)
            {
                while (!sr.EndOfStream)
                    ProcessLinr(sr.ReadLine());
                while (sr.EndOfStream)
                    Thread.Sleep(100);
                ProcessLinr(sr.ReadLine());            
            }
        }
