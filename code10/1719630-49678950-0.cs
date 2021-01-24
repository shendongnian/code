    for (int i = 0; i < numLinesConcYr; i++)
    {
        concYrLine = sr.ReadLine();
        if (!String.IsNullOrEmpty(concYrLine) && concYrLine.Contains("EHRS") == true)
        {
            concArray[i] = concYrLine;
        }
        else
        {
            concYrLine = sr.ReadLine();
        }
    }
