    System.Globalization.CultureInfo mx = new System.Globalization.CultureInfo("es-MX");
    page.Cells["D3:D" + z].Style.Numberformat.Format =mx.DateTimeFormat.ShortDatePattern.ToString();
    //or
    page.Cells["D3:D" + z].Style.Numberformat.Format =mx.DateTimeFormat.LongDatePattern.ToString();
    //or
    page.Cells["D3:D" + z].Style.Numberformat.Format =mx.DateTimeFormat.SortableDateTimePattern.ToString();
