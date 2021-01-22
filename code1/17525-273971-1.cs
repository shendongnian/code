    public class Program
    {
        public string Name
        {
            get { return "My Program"; }
        }
        static void Main()
        {
            MemberInfo member = ReflectionUtility.GetMemberInfo((Program p) => p.Name);
            Console.WriteLine(member.Name);
        }
    }
