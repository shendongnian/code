    Range rngFindBold = doc.Range();
    rngFindBold.Find.Font.Bold = 1;
    while (rngFindBold.Find.Execute(Format: true))
    {
        if (!string.IsNullOrWhiteSpace(rngFindBold.Text))
        {
            MasterSentences.Add(rngFindBold.Text);
        }
    }
