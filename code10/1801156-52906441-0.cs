      public ActionResult Search(string search)
        {
            int year = 0;
            string title = string.Empty;
            string yearparse = string.Empty;
            if (string.IsNullOrWhiteSpace(search))
            {
                return View("Index");
            }
            string movieName = search;
            string movieYear = search;
            for (int i = 0; i < movieName.Length; i++)
            {
                if (char.IsLetter(movieName[i]))
                {
                    title += movieName[i];
                }
            }
            for (int i = 0; i < movieYear.Length; i++)
            {
                if (char.IsDigit(movieYear[i]))
                {
                    yearparse += movieYear[i];
                    year = int.Parse(yearparse);
                }
            }
            var Movies = db.Movies.Where(m => m.Movie_Title.Contains(title) && m.Release_date.Contains(year.ToString())).ToList();
            return View(Movies);
        }
