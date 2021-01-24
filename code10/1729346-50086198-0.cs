    var image = new ImageEntity(){
       imageReference= convertImageToByteArray(image)
    }
    _Context.Images.Add(image);
    _Context.SaveChanges();
