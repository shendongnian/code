    class ComplexClass
    {
        public string Name{ get; set; }
        public string DisplayName{ get; set; }
        public int ComplexID{ get; set; }
    }
    
    List<ComplexClass> complexClassList = new List<ComplexClass>();
    
    complexClassList.Add(new ComplexClass(){Name="1", DisplayName="One", ComplexID=1});
    complexClassList.Add(new ComplexClass(){Name="2", DisplayName="Two", ComplexID=2});
    complexClassList.Add(new ComplexClass(){Name="3", DisplayName="One", ComplexID=1});
    
    // This doesn't produce a distinct list, since the comparison is Default
    List<ComplexClass) uniqueList = complexClassList.Distinct();
    
    class ComplexClassNameComparer : IEquatable<ComplexClass>
    {
        public override bool Equals(GDSConnection x, GDSConnection y)
        {
            return (x.To.DisplayName == y.To.DisplayName);
        }
    
        public override int GetHashCode(GDSConnection obj)
        {
            return obj.To.Name.GetHashCode();
        }
    }
    
    // This does produce a distinct list, since the comparison is specific
    List<ComplexClass) uniqueList = Enumerable.Distinct(complexClassList , new ComplexClassNameComparer());
