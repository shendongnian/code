    var mct = new MultiColumnText(yBottomOfColumnText, MultiColumnText.AUTOMATIC);
    mct.AddSimpleColumn(doc.Left, doc.Right); //creates one column
    for (int i = 0; i < 100; i++)
    {
        mct.AddElement(new Paragraph("Test Paragaph Goes HEREEEEEEEE")); //repeats 100 times for test purposes
    }
    doc.Add(mct);
