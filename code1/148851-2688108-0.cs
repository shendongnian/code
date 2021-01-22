    var genresQuery = from g in Genres select g;
    if ( !string.IsNullOrEmpty( name ) ) genresQuery = genresQuery.Where( g => g.Name == name );
    var titlesQuery = from t in genresQuery select t;
    if ( !string.IsNullOrEmpty( rating ) ) titlesQuery = titlesQuery.Where( t => t.AverageRating == rating );
    if ( !string.IsNullOrEmpty( year ) ) titlesQuery = titlesQuery.Where( t => t.ReleaseYear == year );
