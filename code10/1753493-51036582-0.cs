    public interface IEmailService
    {            
        bool SendEmail();
    }
     public class EmailService:IEmailService
    {            
        public bool SendEmail()
        {
           throw  new Exception("send email failed cuz bla bla bla");
        }
    }
    public class Customer
    {
       public bool AddCustomer(IEmailService emailService)
       {
           emailService.SendEmail();
           Debug.WriteLine("new customer added");
           return true;
       }
    }
    //unit test => no need to make virtual anything
    var mock = new Mock<IEmailService>();
    mock.Setup(x => x.SendEmail()).Returns(true);
