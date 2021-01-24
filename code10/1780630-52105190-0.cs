    using (FileStream fs = new FileStream(sPath, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach (var item in listBox1.Items)
            {
                sw.WriteLine(item);
            }
        }
    }
