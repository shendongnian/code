    public class PhoneNumber {
       public int Id {get; set;}
       public String number {get; set;}
       public int PersonId {get; set;}
       [ForeignKey(nameof(PersonId))]
       public Person PersonNavigation {get; set;}
    }
