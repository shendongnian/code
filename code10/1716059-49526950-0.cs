		public List<string> GetImages()
		{
			string fileName = "";
			string[] files = System.IO.Directory.GetFiles("");
			List<string> listImages = new List<string>();
			foreach (string file in files)
			{
				fileName = System.IO.Path.GetFileName(file);
				listImages.Add(fileName);
			}
			return listImages;
		}
