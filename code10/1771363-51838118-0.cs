    public Emgu.CV.Mat  toMat(Bitmap pic)
    {
    Bitmap bitmap=pic; 
    Emgu.CV.Image<Bgr, Byte> imageCV = new Emgu.CV.Image<Bgr, byte>(bitmap); 
    Emgu.CV.Mat mat = imageCV.Mat; 
    return mat;
    }
