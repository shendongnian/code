    _texture = ReadExternalTexture(material.mainTexture);
    Mat mat = Mat.FromImageData(_texture.EncodeToPNG());
    Cv2.Flip(mat, mat, 0);
    //Flip(src, dest, 0->updown flip / 1->leftright flip)
    Cv2.Resize(mat, mat, new Size(224, 224));
    Cv2.ImShow("Image", mat);
    //Cv2.ImWrite(SavePath + "Image.jpg", mat);
        
