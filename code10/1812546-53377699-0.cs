    private void timer1_Tick(object sender, EventArgs e)
            {
                Random random = new Random();
                List<string> picPaths = new List<string>();
                picPaths.Add("C:\\Users\\seanb\\OneDrive\\Pictures\\cherry.jpg");
                picPaths.Add("C:\\Users\\seanb\\OneDrive\\Pictures\\bell.jpg");
                picPaths.Add("C:\\Users\\seanb\\OneDrive\\Pictures\\lemon.jpg");
                picPaths.Add("C:\\Users\\seanb\\OneDrive\\Pictures\\orange.jpg");
                picPaths.Add("C:\\Users\\seanb\\OneDrive\\Pictures\\star.jpg");
                picPaths.Add("C:\\Users\\seanb\\OneDrive\\Pictures\\skull.jpg");
    
                pictureBox1.Image = Image.FromFile(picPaths[random.Next(picPaths.Count)]);
                pictureBox2.Image = Image.FromFile(picPaths[random.Next(picPaths.Count)]);
                pictureBox3.Image = Image.FromFile(picPaths[random.Next(picPaths.Count)]);
            }
 
