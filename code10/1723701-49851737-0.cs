    public class FluentBuilder<T>
    {
        private readonly T _input;
        private readonly Dictionary<string, string> _mappings = new Dictionary<string, string>();
        public FluentBuilder(T input)
        {
            _input = input;
        }
        public FluentBuilder<T> Map(Expression<Func<T, object>> selector, string name)
        {
            MemberExpression member = selector.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.", selector));
            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", selector));
            _mappings.Add(propInfo.Name, name);
            return this;
        }
        private string GetName(PropertyInfo prop)
        {
            string map;
            if (_mappings.TryGetValue(prop.Name, out map))
                return map;
            return prop.Name;
        }
        public DataTable ToDataTable(string tableName = null)
        {
            var result = new DataTable(tableName);
            foreach (var prop in _input.GetType().GetProperties())
            {
                result.Columns.Add(GetName(prop));
            }
            var values = _input.GetType().GetProperties().Select(x => x.GetMethod.Invoke(_input, new object[0])).ToArray();
            result.Rows.Add(values);
            return result;
        }
    }
    public static class FluentBuilderExtensions
    {
        public static FluentBuilder<T> SetupWith<T>(this T input)
        {
            return new FluentBuilder<T>(input);
        }
    }
    class Program
    {
        public class UserInfo
        {
            public string MailAddress { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        static void Main(string[] args)
        {
            var userInfo = new UserInfo()
                           {
                               MailAddress = "foo@bar.com",
                               Username = "foouser",
                               Password = "barpassword"
                           };
            var dt = userInfo.SetupWith()
                             .Map(x => x.MailAddress, "address")
                             .Map(x => x.Username, "user")
                             .ToDataTable();
        }
    }
