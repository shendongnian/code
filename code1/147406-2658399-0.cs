    public class Foo
    {
         // HttpRequestBase may be more appropriate
         private HttpRequest Request { get; set; }
         public Foo( HttpRequest request )
         {
             this.Request = request;
         }
         public void Bar()
         {
              string path = Path.Combine( this.Request.PhysicalApplicationPath,
                                          "filename.txt" );
              ...
         }
    }
