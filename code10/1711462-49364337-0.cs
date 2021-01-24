    //Loop each row in the dataset and output
    for (int i = 0; i < repDT.Rows.Count; i += 3)
    {
        //Create new table and set columns and widths for Report Items
        PdfPTable itemTable = new PdfPTable(4);
        float[] ITWidths = new float[] { 10f, 20f, 10f, 60f };  //4 columns by size (f) for list of multi-items on report
        itemTable.SetWidths(ITWidths);
        PdfPCell datesvalues = new PdfPCell(new Phrase("" + repDT.Rows[i]["OLDDATE"] + "\n" + Convert.ToDateTime(repDT.Rows[i]["INSDATE"]).ToString("dd/MM/yyyy") + "\n" + Convert.ToDateTime(repDT.Rows[i]["NEXT DATE"]).ToString("dd/MM/yyy") + "\n" + repDT.Rows[i]["CONT FREQ"].ToString() + " months", smalltext));
        itemTable.AddCell(datesvalues);
        PdfPCell itemdetails = new PdfPCell(new Phrase("1. " + repDT.Rows[i]["DESC"] + "\n" + "2. " + repDT.Rows[i]["PLANTNUMBER"] + "\n" + "3. " + repDT.Rows[i]["SERIALNUMBER"] + "\n" + "4. " + repDT.Rows[i]["SUBLOC"].ToString(), smalltext));
        itemTable.AddCell(itemdetails);
        PdfPCell swl = new PdfPCell(new Phrase("" + repDT.Rows[i]["SWL"], smalltext));
        itemTable.AddCell(swl);
        PdfPCell defects = new PdfPCell(new Phrase("A. " + repDT.Rows[i]["ADEFECT"] + "\n" + "B. " + repDT.Rows[i]["BDEFECT"] + "\n" + "C. " + repDT.Rows[i]["OBS"] + "\n" + "" + repDT.Rows[i]["SPARE1"].ToString(), smalltext));
        itemTable.AddCell(defects);
        document.Add(itemTable);
        document.NewPage();
    }
