    public class MyVertex: Vertex<MyVertex>
    {
      public int Id { get; set; }
    }
    var a = new MyVertex {Id = 1 };
    var b = new MyVertex { Id = 2 };
    a.Vertices = new List<MyVertex > { b };
    b.Vertices = new List<MyVertex > { a };
    
    var bId = a.Vertices.First().Id;
    // or even
    var aId = a.Vertices.First().Vertices.First();
