    public class MyPerson : Person
    {
        public new int Id 
        { 
            get
            {
                foo();
                return base.Id;
            }
    }
