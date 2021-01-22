       public class MyCalısan{
    public List<Calısan> list { get; set; }
    public MyCalısan()
    {
        list = new List<Calısan>();
    }}
      foreach (Calısan item in myCalısan.list)
            {
                Console.WriteLine(item.Ad.ToString());
            }
