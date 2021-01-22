    public abstract BaseClass : System.Web.UI.UserControl
    {
      private static List<string> collection = new List<string>();
      private static string csvString = String.Empty;
      public virtual void Process(string sType)
      {
         //to create a list
         collection.Add(sType);
         //Or to create just a csv string
         csvString += sType + ",";
      }
    }
