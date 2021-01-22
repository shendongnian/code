    public class Class2
    {
        public void SomeFunction()
        {
            Class1<TypeIWant>.ValidateMove = new ValidateDelegate<TypeIWant>(functionThatHasCorrectSigniture)
        }
    }
