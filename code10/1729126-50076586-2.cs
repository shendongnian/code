    public Form1()
    {
        InitializeComponent();
    }
    
    public void ChangePicImg(Image newImage)
    {
        picBtn.Image = newImage;
    }
    private void picBtn_Click(object sender, EventArgs e)
    {
       Form2 form2 = new Form2();
       form2.ShowDialog();    
    }
