    public class SomeClass
    {
        public void SomeMethod([CallerMemberName]string memberName = "")
        {
            Console.WriteLine(memberName); //output will be name of calling method
        }
    }
