    public void Page_Load(object sender, EventArgs e)
    {
      var myData = MyDataSource.GetPeople();
      list.DataSource = myData;
      list.SelectedIndex = myData.FirstIndexOf(p => p.Name.Equals("Bob", StringComparison.InvariantCultureIgnoreCase));
      list.DataBind();
    }
    
    
    public static class EnumerableExtensions
    {
        public static int FirstIndexOf<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            int count = 0;
            foreach(var item in source)
            {
                if (predicate(item))
                    return count;
                count++;
            }
            return -1;
        }
    }
