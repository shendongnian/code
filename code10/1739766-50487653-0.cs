            [HttpPost]
        public Void AddRating(int id, int rating)
        {
            double temp = rating;
            var saloon = db.Saloon.Find(id);
            saloon.Rating += temp;
            saloon.NumberOfRatings ++;
            db.SaveChanges();}
