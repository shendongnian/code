		public void DisplayFolder ( string folderPath )
		{
			string[ ] files = System.IO.Directory.GetFiles( folderPath );
			for ( int x = 0 ; x < files.Length ; x++ )
			{
				lvFiles.Items.Add( files[x]);
			}
		}
