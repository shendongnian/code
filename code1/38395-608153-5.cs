    int j = 0;
    foreach (Microsoft.Office.Interop.Word.Page p in pane.Pages)
    {
        var bits = p.EnhMetaFileBits;
        var target = path1 +j.ToString()+  "_image.doc";
        try
        {
            using (var ms = new MemoryStream((byte[])(bits)))
            {
                var image = System.Drawing.Image.FromStream(ms);
                var pngTarget = Path.ChangeExtension(target, "png");
                image.Save(pngTarget, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message);  
        }
        j++;
    }
