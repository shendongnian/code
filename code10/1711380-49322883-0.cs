    public class MyPictureBox : PictureBox
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    MyPictureBox box = new MyPictureBox()
    {
        Name = "pcBox1",
        X = 1,
         Y = 2
    };
    
    box.MouseHover += pictureBox1_MouseHover;
