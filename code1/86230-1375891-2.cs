    public class Tenement
    {
         public Tenement()
         {
             this.polygons = new List<Polygon>(); // Create the list here...
         }
         private List<Polygon> polygons;
         public int Id { get; set; }
         public IEnumerable<Polygon> Polygons { 
            get { return this.polygons; }
         }
         public void AddPolygon(Polygon polygon) {
             // Do extra stuff here, then:
             this.polygons.Add(polygon);
         }
         // ...
