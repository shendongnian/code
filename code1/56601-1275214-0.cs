    public ActionResult GetImage(int id)
    {
        byte[] imageData = storeRepository.ReturnImage(id);
        //instead of what augi wrote using the binarystreamresult this was the closest thing i found so i am assuming that this is what it evolved into 
        return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
    }
    //in my repository class where i have all the methods for accessing data i have this
    public byte[] ReturnImage(int id)
    {
        // i tried his way of selecting the right record and preforming the toArray method in the return statment 
        // but it kept giving me an error about converting linq.binary to byte[] tried a cast that didnt work so i came up with this
        byte[] imageData = GetProduct(id).ProductImage.ToArray();
        return imageData;
    }
 
