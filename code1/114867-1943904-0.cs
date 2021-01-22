    public class picMover
    {
        // note use of C# 3.0 automatic property feature here
        public PictureBox myPictureBox { get; set; }
    
        public void movePic(int distance)
        {
            // note test for null here
            if (myPictureBox != null)
            {
                myPictureBox.Left += distance;
            }
        }
    }
