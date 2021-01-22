    public interface IPhoneable
    {
         public PhoneNumber GetPrimaryNumber();
         public void AddNumber( PhoneNUmber number );
         public IEnumerable<PhoneNumber> GetNumbers();
    }
    public interface IEmailable
    {
         public EmailAddress GetPrimaryAddress();
         public void AddEmailAddress( EmailAddress address );
         public IEnumerable<EmailAddress> GetEmailAddresses();
    }
    public class Contact : IPhoneable, IEmailable
    {
         private List<PhoneNumber> phoneNumbers;
         private List<EmailAddresses> emailAddresses;
         public int ContactID { get; private set; }
         public string FirstName { get; set; }
         ...
         public Contact()
         {
             this.phoneNumbers = new List<PhoneNumber>();
             this.emailAddresses = new List<EmailAddress>();
         }
         public PhoneNumber GetPrimaryNumber()
         {
              foreach (PhoneNumber number in this.phoneNumbers)
              {
                   if (number.IsPrimary)
                   {
                        return number;
                   }
              }
              return null;
          }
          ...
    }
