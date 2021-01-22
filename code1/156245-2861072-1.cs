            AlbumList albums = new AlbumList();
            albums.Add(new Album { Artist = "artist1", Title = "title1" });
            albums.Add(new Album { Artist = "artist2", Title = "title2" });
            for (int i = 0; i < albums.Count; i++)
            {
                Console.WriteLine(albums[i].Artist);
                Console.WriteLine(albums[i].Title);
            }
            Console.WriteLine("title for artist1");
            Console.WriteLine(albums["artist1"].Title);
