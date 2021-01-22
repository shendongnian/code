    public ActionResult CropImage(string hdnx, string hdny, string hdnw, string hdnh)
    {
        string fname = "pool.jpg";
        string fpath = Path.Combine(Server.MapPath("~/images"), fname);
        Image oimg = Image.FromFile(fpath);
        Rectangle cropcords = new Rectangle(
        Convert.ToInt32(hdnx),
        Convert.ToInt32(hdny),
        Convert.ToInt32(hdnw),
        Convert.ToInt32(hdnh));
        string cfname, cfpath;
        Bitmap bitMap = new Bitmap(cropcords.Width, cropcords.Height,img.PixelFormat);
        Graphics grph = Graphics.FromImage(bitMap);
        grph.DrawImage(oimg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), cropcords, GraphicsUnit.Pixel);
        cfname = "crop_" + fname;
        cfpath = Path.Combine(Server.MapPath("~/cropimages"), cfname);
        bitMap.Save(cfpath);
    
        return Json("success",JsonRequestBehavior.AllowGet);
    }
