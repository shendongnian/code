    public class SomeClass
    {
        public void SomeMethod([CallerMemberName]string memberName = "")
        {
            Console.WriteLine(memberName); //The output will be the name of calling method.
        }
    }
