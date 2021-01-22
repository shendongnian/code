	private Bitmap RotateImage(Bitmap rotateMe, float angle)
	{
		//First, re-center the image in a larger image that has a margin/frame
		//to compensate for the rotated image's increased size
		
		var bmp = new Bitmap(rotateMe.Width + (rotateMe.Width / 2), rotateMe.Height + (rotateMe.Height / 2));
		using (Graphics g = Graphics.FromImage(bmp))
			g.DrawImageUnscaled(rotateMe, (rotateMe.Width / 4), (rotateMe.Height / 4), bmp.Width, bmp.Height);
		bmp.Save("moved.png");
		rotateMe = bmp;
		//Now, actually rotate the image
		Bitmap rotatedImage = new Bitmap(rotateMe.Width, rotateMe.Height);
		using (Graphics g = Graphics.FromImage(rotatedImage))
		{
			g.TranslateTransform(rotateMe.Width / 2, rotateMe.Height / 2);   //set the rotation point as the center into the matrix
			g.RotateTransform(angle);                                        //rotate
			g.TranslateTransform(-rotateMe.Width / 2, -rotateMe.Height / 2); //restore rotation point into the matrix
			g.DrawImage(rotateMe, new Point(0, 0));                          //draw the image on the new bitmap
		}
		rotatedImage.Save("rotated.png");
		return rotatedImage;
	}
