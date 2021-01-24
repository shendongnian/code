        Bitmap img = new Bitmap(pictureBox1.Image);
        Image<Bgr, byte> imgInput = new Image<Bgr, byte>(img);
        using (Mat modelImage = CvInvoke.Imread("C:\\model.jpg", ImreadModes.Color)) //works
        using (Mat observedImage = new Image<Bgr, byte>(img).Mat) //works too
        {
            Mat result = DrawMatches.Draw(modelImage, observedImage, out matchTime);
            ImageViewer.Show(result, String.Format("Matched in {0} milliseconds", matchTime));
        }
   
   
