    var basePath =
        @"C:\Users\scatt\Desktop\Marvel-J.A.R.V.I.S-Personal-Assistant-Winform-C--master\Marvel J.A.R.V.I.S Personal Assistant\Resources\AIPICS\";
    
    var pics = new[] {"pic1.jpg", "pic2.jpg"};
    var randomPic = pics.OrderBy(p => Guid.NewGuid()).First();
    pictureBox2.Image = MediaTypeNames.Image.FromFile(basePath+randomPic);
    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
    pictureBox1.CancelAsync();
