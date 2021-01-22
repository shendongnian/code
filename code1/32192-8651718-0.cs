    List<Student>.Distinct(new IEqualityComparer<Student>() 
    { 
        public override bool Equals(Student x, Student y)
        {
            return x.Id == y.Id;
        }
    
        public override int GetHashCode(Student obj)
        {
     	    return obj.Id.GetHashCode();
        }
    })
