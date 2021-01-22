    public static class PersonExtensions {
       public PersonViewData ViewData(this Person p) {
           return new PersonViewData(p);
       }
    }
    public class PersonViewData {
         public PersonViewData(Person p) {
             this._person = p;
         }
         private Person p;
         public string FormattedPhoneNumber {
             get { return p.PhoneNumber.ToPrettyString(); // or whatever }
         }
    }
