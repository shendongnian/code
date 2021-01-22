    class Professor
    {
    
       public string Name { get; set; }
       public override bool Equals(object cust)
       {
           if (cust == null || !(cust is Professor)) return false;
           return cust.Name == this.Name;
       }
    
    }
