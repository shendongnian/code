       var imageAsByteArray = File.ReadAllBytes(imagePath);
       // I use as example a pictureBox:
       pictureBox1.Image = byteArrayToImage(imageAsByteArray);
       // Or/and safe/copy/replace it:
       File.WriteAllBytes(picture_Path, imageAsByteArray);
