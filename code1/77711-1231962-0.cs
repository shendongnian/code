    public class ServerPathMapper : IPathMapper {
         public string MapPath(string relativePath){
              return HttpContext.Server.MapPath(relativePath);
         }
    }
