    List<string> movieList = new List<string>;
    movieList.Add(File.ReadAllLines("C:\\movies.txt"));
    List<string> retrievedList = new List<string>; ///The list of retrieved movie list
    retrievedList.Add(File.ReadAllLines("C:\\retrievedmovies.html"));
    foreach (var item in retrievedList)
    {
        if (movieList.Contains(item) == true)
        {
        continue;
         MessageBox.Show(item)
        }
        else
        {
        }
    }
