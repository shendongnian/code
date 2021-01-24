    public static class OutlookExtensions {
        public OlObjectClass GetOutlookObjectClass(this object item){
              (OlObjectClass)item.GetType().InvokeMember(
         "Class", 
         BindingFlags.GetProperty|BindingFlags.Public, 
         null, 
         item, 
         null);
        }
    }
