    Image backImg = Image.FromFile("bg.jpg");
    Image mrkImg = Image.FromFile("watermark.png");
    Graphics g = Graphics.FromImage(backImg);
    g.DrawImage(mrkImg backImg.Width/2, 10);
    backImg.Save("result.jpg");
