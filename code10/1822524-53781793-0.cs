    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApp1
    {
        class Program
        {
            class Contact
            {
                public string Landline { get; set; }
                public string Mobile { get; set; }
            }
    
            class Person
            {
                public string Name { get; set; }
                public List<Contact> ContactInfo { get; set; }
            }
    
            static void Main(string[] args)
            {
                Person person = new Person();
                person.ContactInfo = new List<Contact>();
                person.ContactInfo.Add(new Contact { Landline = "123456", Mobile = "7654332"});
    
                PropertyInfo contactInfoPropertyInfo = person.GetType().GetProperty(nameof(Person.ContactInfo));
                List<Contact> contactInfoValue = contactInfoPropertyInfo.GetValue(person, null) as List<Contact>;
                Contact firstContact = contactInfoValue?.First();
                string landline = firstContact?.GetType().GetProperty(nameof(Contact.Landline))?.GetValue(firstContact, null) as string;
                string mobile = firstContact?.GetType().GetProperty(nameof(Contact.Mobile))?.GetValue(firstContact, null) as string;
    
                Console.WriteLine(landline);
                Console.WriteLine(mobile);
            }
        }
    }
