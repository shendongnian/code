        if (string.IsNullOrWhiteSpace(search))
            {
        return View("Index");
             }
                string digit = new String(search.Where(Char.IsDigit).ToArray());
                string letter = new String(search.Where(Char.IsLetter).ToArray());
    var Movies = db.Movies.Where(m => m.Movie_title.Contains(letter) || m.Release_date.Contains(digit)).ToList();//if Release_Date type is string 
       //for datetime type(just for year)
    var Movies = db.Movies.Where(m => m.Movie_title.Contains(letter) || m.Release_date.Year==digit).ToList();
          
     }
