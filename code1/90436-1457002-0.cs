    public class Installation : Entity<Installation>
    {        
        public virtual string Name { get; set; }
        public virtual IList<Institution> Institutions { get; set; }
    
        public Installation()
        {
            Institutions = new List<Institution>();
        }
    
        public virtual void AddInstitution(Institution entity)
        {
            entity.Installation = this;
            Institutions.Add(entity);
        }
    }
