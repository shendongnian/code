     tblMovieGenre genre = new tblMovieGenre();
     // code...
     foreach (var GenreId in GenreId)
     {
         genre.GenreId = this.GenreId.FirstOrDefault();
         // code
         dc.tblMovieGenres.Add(genre);
     }
