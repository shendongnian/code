    List<PictureBox> logos = new List<PictureBox>();   
    private List<PictureBox> Insert_Logo()
    {
        PictureBox pic1 = new PictureBox();
        Image image = Image.FromFile("D:\\Project\\Mini-Game\\Mini-Game\\bin\\Image\\Renault.bmp");
        pic1.Image = image;
        PictureBox pic2 = new PictureBox();
        Image a = Image.FromFile("D:\\Project\\Mini-Game\\Mini-Game\\bin\\Image\\vw.bmp");
        pic2.Size = new Size(a.Width, a.Height);
        pic2.Image = a;
        PictureBox pic3 = new PictureBox();
        Image s = Image.FromFile("D:\\Project\\Mini-Game\\Mini-Game\\bin\\Image\\alfa.bmp");
        pic3.Size = new Size(s.Width, s.Height);
        pic3.Image = s;
        logos.Add(pic1);
        logos.Add(pic2);
        logos.Add(pic3);
        return logos;
    }
    private void PictuteBox_CLICK(object sender, EventArgs e)
    {
        logos = Insert_Logo();
        //The Insert_Logo function returns a list of pictureboxes.
        int randomnumber;
        randomnumber = random.Next(0, logos.Count);
        //Replace Picturebox with the name of the picturebox you want to show the image in
        Picturebox.Image = logos[randomnumber].Image;
        logos.RemoveAt(randomnumber); 
    }
