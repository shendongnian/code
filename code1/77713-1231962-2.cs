    public class ServerPathMapper : IPathMapper {
         public string MapPath(string relativePath){
              return HttpContext.Current.Server.MapPath(relativePath);
         }
    }
