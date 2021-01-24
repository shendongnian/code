    public interface IUpdateable 
    { 
        DateTime UpdatedOn { get; set; }  
    }
    public class Registro : IUpdateable
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
