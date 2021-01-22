    static class Extensions
    {
       static string ToStringAll(this List<Marker> markers)
       {
          string all = "";
          foreach (var marker in markers)
          {
             all += marker.ToString() + ",";
          }
          return all.Trim(',');
       }
    }
