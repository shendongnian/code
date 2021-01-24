    public class ContactProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} {BirthDate.ToShortDateString()}";
        }
    }
    public class RegistrationModel
    {
        public ContactProfileModel ContactProfile { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var registration = new RegistrationModel
            {
                ContactProfile = new ContactProfileModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = DateTime.Now
                }
            };
            var expression = Contact<RegistrationModel>(m => m.ContactProfile);
            Console.WriteLine(expression.Compile()(registration));
            Console.ReadKey();
        }
        public static Expression<Func<TModel, string>> Contact<TModel>(Expression<Func<TModel, ContactProfileModel>> contact)
        {
            var propertyAccess = (MemberExpression)contact.Body;
            var toString = typeof(ContactProfileModel).GetMethod("ToString");
            var toStringValue = Expression.Call(propertyAccess, toString);
            return Expression.Lambda<Func<TModel, string>>(toStringValue, contact.Parameters[0]);
        }
    }
