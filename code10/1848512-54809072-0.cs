    //JCPS Logo
    TableCell tc = new TableCell();
    HtmlImage studPic = new HtmlImage();
    if (HttpContext.Current.Request.IsLocal)
        studPic.Src = "/Dev/Data Management Center/Images/JCPS Logo.png";
    else
        studPic.Src = "/Website/DMC/Images/JCPS Logo.png";
    studPic.Height = 125;
    studPic.Width = 150;
    tc.Controls.Add(studPic);
    tr.Cells.Add(tc);
