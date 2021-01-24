    public class Model
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        [NotMapped]
        public int SrNo { get; set; }
        [NotMapped]
        public int Salary{ get; set; }
        public List<EntityName> lstData { get; set; }
        public Model()
        {
            lstData = new List<EntityName>();
        }
    }
