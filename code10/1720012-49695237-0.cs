    System.Collections.ArrayList Webpages = new System.Collections.ArrayList();
    string fileName = "Medium.txt";
    string fileContent = "";
    using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
    {
        /* loads all the file into a string */
        fileContent = sr.ReadToEnd();
    }
    /* split the file's contents, StringSplitOptions.RemoveEmptyEntries will remove the last empty element (the one after Webpage7,) */
    string[] data = fileContent.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    /* packs of 3 (1st the double, 2nd the int and 3rd the string) */
    for (int i = 0; i < data.Length; i += 3)
    {
        /* double parse with CultureInfo.InvariantCulture as per Hans Passant comment */
        Webpage newEntry = new Webpage(
            double.Parse(data[i], System.Globalization.CultureInfo.InvariantCulture),
            int.Parse(data[i + 1]),
            data[i + 2].Trim());
        Webpages.Add(newEntry);
    }
