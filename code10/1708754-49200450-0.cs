    var files = Directory.EnumerateFiles("C:\\path", "*.*", SearchOption.AllDirectories)
        .Where(s => s.Contains("partialFileName"));
    int cnt4 = 0;
    foreach (var file in files)
    {
        var lines3 = System.IO.File.ReadAllLines(file);
        bestPathL3 = new float[lines3.Length, 2];
        foreach (string line in lines3)
        {
            string[] temp = line.Split(' ');
            bestPathL3[cnt4, 0] = (float)double.Parse(temp[0]);
            bestPathL3[cnt4, 1] = (float)double.Parse(temp[1]);
            cnt4++;
            //Do something with bestPathL3
        }
    }
