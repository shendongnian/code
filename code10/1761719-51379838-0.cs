    private void button1_Click(object sender, EventArgs e)
	{
        IDataObject obj = Clipboard.GetDataObject();
        Image img1 = Clipboard.GetImage();
        //now do with the image whatever you want, you may want to store it as a public field thought to
        //access the image in your whole application
	}
