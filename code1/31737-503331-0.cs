    string DecodedString = string.Empty;
    DecodedString = System.Convert.ToBase64String(bytes)
    sResult = sResult + "<Photo>" +XmlConvert.EncodeName(DecodedString) + "</Photo>";
...
    byte[] bytes = System.Convert.FromBase64String(xDocument.SelectSingleNode("Response/Images/Photo").InnerText);
    using(System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
        System.Drawing.Bitmap b = System.Drawing.Image.FromStream(ms);
