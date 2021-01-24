    string scanToolDateFinalStgT1 = "";
    DateTime scanToolDateFinalT1 = new DateTime(2000, 1, 1, 1, 1, 00);
    for (int k = 0; k < scanToolT1Pass.Count(); k++)
    {
        string scanToolPassNameOnly = Path.GetFileNameWithoutExtension(scanToolT1Pass[k].ToString());
        string scanToolDateStr = scanToolPassNameOnly.Substring(scanToolPassNameOnly.IndexOf("[") + 1, 8);
        string scanToolTimeStr = scanToolPassNameOnly.Substring(scanToolPassNameOnly.LastIndexOf("[") + 1, 5);
        DateTime currentScanToolDate = DateTime.ParseExact(scanToolDateStr + " " + scanToolTimeStr, "MM-dd-yy HH_mm", null);
        if (currentScanToolDate > scanToolDateFinalT1)
        {
            scanToolDateFinalT1 = currentScanToolDate;
            scanToolDateFinalStgT1 = scanToolT1Pass[k].ToString();
        }
    }
