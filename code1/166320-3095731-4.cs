    public class SomeClass
    {
        public void SomeMethod([CallerMemberName]string memberName = "")
        {
            Console.WriteLine(memberName); //output will me name of calling method
        }
    }
