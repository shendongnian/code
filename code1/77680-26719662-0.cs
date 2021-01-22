		public static byte[] ToByteArray(this Image imageIn)
		{
			MemoryStream ms = new MemoryStream();
			imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
			return ms.ToArray();
		}
		public static Image AttachMetadData(this Image imgModified, Image imgOriginal)
		{
			using (MagickImage imgMeta = new MagickImage(imgOriginal.ToByteArray()))
			using (MagickImage imgModi = new MagickImage(imgModified.ToByteArray()))
			{
				foreach (var profileName in imgMeta.ProfileNames)
				{
					imgModi.AddProfile(imgMeta.GetProfile(profileName));
				}
				imgModified = imgModi.ToImage();
			}
			return imgModified;
		}
