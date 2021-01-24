    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
    public class Vehicle
    {
        public int Id { get; set; }
        public string lic_number { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
