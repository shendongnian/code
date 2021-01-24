    public abstract class Form
    {
        public Form(string xx, string yy)
        {
            SentByName = xx;
            SentByEmail = yy;
            ReceivedByDateTime = Date.Now;
        }
    }
    public class Customer: Form
    {
        public Customer(string xx, string yy) : base(xx,yy)
        {
        }
    
        public int Id { get; set; }
        public string FirstName{ get; set; }   
        public string Surname { get; set; }
    }
