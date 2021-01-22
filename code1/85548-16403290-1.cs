    using System.ComponentModel.DataAnnotations;
    class ValidateSomeEmails
    {
        static void Main(string[] args)
        {
            var foo = new EmailAddressAttribute();
            bool bar;
            bar = foo.IsValid("someone@somewhere.com");         //true
            bar = foo.IsValid("someone@somewhere.co.uk");       //true
            bar = foo.IsValid("someone+tag@somewhere.net");     //true
            bar = foo.IsValid("futureTLD@somewhere.fooo");      //true
            bar = foo.IsValid("fdsa");                          //false
            bar = foo.IsValid("fdsa@");                         //false
            bar = foo.IsValid("fdsa@fdsa");                     //false
            bar = foo.IsValid("fdsa@fdsa.");                    //false
    
            //one-liner
            if (new EmailAddressAttribute().IsValid("someone@somewhere.com"))
                bar = true;    
        }
    }
