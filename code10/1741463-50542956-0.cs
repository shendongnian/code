    //Flip picture
    var img = m.ToImage<Bgr, byte>();
    img = img.Rotate(180, new Bgr(Color.Red)).Flip(Emgu.CV.CvEnum.FlipType.Vertical);
    // show it 
    imageBox1.Image = img;
