    var a = from rating in _db.Ratings
            join ratingCat in _db.RatingCategories
                on rating.RatingCategoryID equals ratingCat.RatingCategoryID
            where rating.UserID == UserID
                && rating.EntityID == EntityID
            orderby rating.DateSubmitted descending
            select new RatingViewModel
             {
                 Rater = rating.User,
                 RaterRating = rating,
                 RatingCategory = ratingCat
             }
             .Take(10);
