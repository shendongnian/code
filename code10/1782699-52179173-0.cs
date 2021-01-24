    public class FavoriteClassList
    {
       public int ID { get; set; }
       public string Name { get; set; }
    }
    public static ObservableCollection<FavoriteClassList> _FavoriteClassList = new ObservableCollection<FavoriteClassList>();
        
        
    for (int m=1;m<=10;m++)
    {
       FavoriteClassList objFavoriteClassList = new FavoriteClassList();
       objFavoriteClassList.ID = m;
       objFavoriteClassList.Name  = "Name"+m;
       _FavoriteClassList.Add(objFavoriteClassList);
    }
