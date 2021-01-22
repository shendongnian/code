    XDocument doc = XDocument.Load(filename);
    var pages = doc.Root.Elements("page").Where(page => (int?) page.Attribute("no") == 1);
    var rows = pages.SelectMany(page => page.Elements("row"));
    var pics = rows.SelectMany(row => row.Elements("pic").Where(pic => (int?) pic.Attribute("pos") == 1));
    foreach (var pic in pics)
    {
        // outputs <pic pos="1" src="D:\RuthSiteFiles\webSiteGalleryClone\ruthCompPics\C_WebBigPictures\100CANON\IMG_0418.jpg" width="150" height="120">1</pic>
        Console.WriteLine(pic);
        // outputs 1
        Console.WriteLine(pic.Value);
        // Changes the value
        pic.Value = 2;
    }
    doc.Save(filename);
