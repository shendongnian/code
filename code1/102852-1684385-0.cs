        public void Build()
        {
            FindAlbums(Root);
            // Final update
            if (Library_Finished != null)
            {
                Library_Finished(this, null);
            }
        }
        private void FindAlbums(string root)
        {
            // Find all the albums
            string[] folders = Directory.GetDirectories(root);
            foreach (string folder in folders)
            {
                string[] files = Directory.GetFiles(folder, "*.mp3");
                if (files.Length > 0)
                {
                    // Add to library - use first file as being representative of the whole album
                    var info = new AlbumInfo(files[0]);
                    if (Library_AlbumAdded != null)
                    {
                        Library_AlbumAdded(this, new AlbumInfoEventArgs(info));
                    }
                }
                FindAlbums(folder);
            }
        }
