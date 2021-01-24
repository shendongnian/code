        string path = "Your Path";
        bool available = true;
        try
        {
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                
            }
        }
        catch(Exception ex)
        {
            available = false;
        }
