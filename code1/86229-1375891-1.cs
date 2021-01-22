    public class Tenement
    {
         public Tenement()
         {
             this.Polygons = new List<Polygon>(); // Create the list here...
         }
         public int Id { get; set; }
         public IList<Polygon> Polygons { get; private set; }
         // ...
