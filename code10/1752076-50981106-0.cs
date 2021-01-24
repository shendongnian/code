    Bitmap bmp = new Bitmap("C:\\Test\\test.jpg");
    foreach (System.Drawing.Imaging.PropertyItem item in bmp.PropertyItems)
    {
        if (item.Id == 0x0112 || item.Id == 0x0132)
            continue;
        System.Drawing.Imaging.PropertyItem modItem = item;
        modItem.Value = new byte[]{0};
        bmp.SetPropertyItem(modItem);
    }
    bmp.Save("C:\\Test\\noexif.jpg");
