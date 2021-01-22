    public class Util
    {
        //common util method
        public static void AddPhoneNumber(object obj, string phoneNumber)
        {
             if(obj is Contact)
                 ((Contact)contact).Phones.Add(phoneNumber);
             else if(obj is Person)
                 ((Person)contact).Phones.Add(phoneNumber);
        }
        //extension method for Person
        public static void AddPhoneNumber(this Person p, string phoneNumber)
        {
            AddPhoneNumber((object)p, phoneNumber);
        }
        //extension method for Contact
        public static void AddPhoneNumber(this Contact c, string phoneNumber)
        {
            AddPhoneNumber((object)c, phoneNumber);
        }
    }
