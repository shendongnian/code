    public class Program
    {
        private static readonly MethodInfo stringConcatMethod = typeof(string).GetMethod("Concat", new[] { typeof(string[]) });
        private static readonly MethodInfo toShortTimeStringMethod = typeof(DateTime).GetMethod("ToShortTimeString");
        private static readonly PropertyInfo firstNameProperty = typeof(ContactProfileModel).GetProperty("FirstName");
        private static readonly PropertyInfo lastNameProperty = typeof(ContactProfileModel).GetProperty("LastName");
        private static readonly PropertyInfo birthDateProperty = typeof(ContactProfileModel).GetProperty("BirthDate");
        public static void Main()
        {
            var result = Contact<RegistrationModel>(x => x.ContactProfile);
            // Test it
            var model = new RegistrationModel()
            {
                ContactProfile = new ContactProfileModel()
                {
                    FirstName = "First",
                    LastName = "Last",
                    BirthDate = DateTime.Now,
                }
            };
            var str = result.Compile()(model);
        }
        public static Expression<Func<TModel, string>> Contact<TModel>(Expression<Func<TModel, ContactProfileModel>> contact)
        {
            // We've been given a LambdaExpression. It's got a single
            // parameter, which is the 'x' above, and its body
            // should be a MemberExpression accessing a property on
            // 'x' (you might want to check this and throw a suitable
            // exception if this isn't the case). We'll grab the
            // body of the LambdaExpression, and use that as the
            // 'm.ContactProfile' expression in your question. 
            // At the end, we'll construct a new LambdaExpression
            // with our body. We need to use the same ParameterExpression
            // given in this LambdaExpression.
            var modelParameter = contact.Parameters[0];
            var propertyAccess = (MemberExpression)contact.Body;
            // <contact>.FirstName
            var firstNameAccess = Expression.Property(propertyAccess, firstNameProperty);
            // <contact>.LastName
            var lastNameAccess = Expression.Property(propertyAccess, lastNameProperty);
            // <contact>.BirthDate
            var birthDateAccess = Expression.Property(propertyAccess, birthDateProperty);
            // <contact>.BirthDate.ToShortTimeString()
            var birthDateShortTimeStringCall = Expression.Call(birthDateAccess, toShortTimeStringMethod);
            // string.Concat(new string[] { <contact>.FirstName, " ", etc }
            var argsArray = Expression.NewArrayInit(typeof(string), new Expression[]
            {
                firstNameAccess,
                Expression.Constant(" "),
                lastNameAccess,
                Expression.Constant(" "),
                birthDateShortTimeStringCall
            });
            var concatCall = Expression.Call(stringConcatMethod, argsArray);
            // Turn it all into a LambdaExpression
            var result = Expression.Lambda<Func<TModel, string>>(concatCall, modelParameter);
            return result;
        }
    }
    public class ContactProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class RegistrationModel
    {
        public ContactProfileModel ContactProfile { get; set; }
    }
