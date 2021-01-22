    public static class NameValueCollectionExtensions
    {
       public static Dictionary<string,string> ToDictionary( this NameValueCollection collection )
       {
          Dictionary<string,string> temp = new Dictionary<string,string>();
          foreach (string key in collection)
          {
              temp.Add(key,collection[key]);
          }
          return temp;
       }
    }
    private void BindList(NameValueCollection nvpList)
    {
       resultGV.DataSource = nvpList.ToDictionary();
       resultGV.DataBind();
    }
