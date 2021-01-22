    public InheritingClass : BaseClass
    {
         public InheritingClass()
         {
              Values = new InhertingList<string>(); ?
         }
    
         public new List<string> Values { get; private set; }
    }
