    using (FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
        using (StreamReader rd1 = new StreamReader(fs1))
        {
            while ((str = rd1.ReadLine()) != null)
            {
                //do stuff
            }
        }
    }
