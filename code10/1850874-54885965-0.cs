    public void Capture_Image()
        {
            try
            {
                capture = new VideoCapture();
                Bitmap tempImg = capture.QueryFrame().Bitmap;
                pictureBox2.Image = null;
                pictureBox2.Image = tempImg;
                pictureBox2.Refresh();
                tempImg.Save("C:/FHT59N3/Bildanalyse_Projekt/image.jpg");
                tempImg.Dispose();
                capture.Dispose();
            }
            catch (NullReferenceException)
            {
                string message = "No Camera found";
                string title = "Please connect Camera";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }
