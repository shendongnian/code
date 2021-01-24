     Image img = Image.FromFile(@"images\dcw.png");
     int picBoxIndex = tabPanl.Controls.GetChildIndex(picBox1x1);
    tabPanl.Controls[picBoxIndex].Paint += (s,e) =>{
       e.Graphics.DrawImage(img,
                new Rectangle(0, 0, 50, 50),
                new Rectangle(img.Width / 2 - 25, img.Height / 2 - 25, 50, 50),
                GraphicsUnit.Pixel);
    };
        
