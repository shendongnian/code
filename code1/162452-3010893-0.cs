    using Iesi.Collections.Generic;
    namespace Sample
       {
       public class MyItem
          {
          public virtual string Id { get; set; }
          public virtual string Name { get; set; }
          public virtual string Version { get; set; }
    
          public virtual ISet<MyItem> Dependants { get; set; }
    
          }
       }
