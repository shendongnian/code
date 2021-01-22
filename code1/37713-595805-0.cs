    public class MappedAttribute : Attribute
    {
    }
    public class Person
    {
        [Mapped]
        public string FirstName { get; set; }
   
        [Mapped]
        public string LastName { get; set; }
        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
    public static class Mapper
    {
        public static IList<string> Attributes( Type t )
        {
              List<string> attributes = new List<string>();
          
              foreach (PropertyInfo pInfo in t.GetProperties())
              {
                  MappedAttribute attr = pInfo.GetCustomAttributes(typeof(MappedAttribute),false)
                                              .Cast<MappedAttribute>()
                                              .FirstOrDefault();
                  if (attr != null)
                  {
                      attributes.Add(pInfo.Name);
                  }
              }
              
              return attributes;
        }
    }
