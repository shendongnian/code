    private void button1_Click(object sender, EventArgs e)
    {
    	string imgFilePath = Islem.getFileName();
    	if (!string.IsNullOrEmpty(imgFilePath)
    	{
    		Image<Bgr, byte> img = new Image<Bgr, byte>(Islem.getFileName());
    		ımageBox1.Image = img;
    	}
    }
