    public class TargetModel
    {
        public int Id { get; set; }
        public IAddress AbstractAddress { get; set; }
    }
    public interface IAddress
    {
        string Address01 { get; set; }
    }
    public class Address : IAddress
    {
        public string Address01 { get; set; }
    }
