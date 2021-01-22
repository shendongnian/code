    public class BaseClass
    {
        private const int _aNumber = 5;
        public int ReturnANumber() { return _aNumber; }
    }
    public class DClass : BaseClass
    {
        public void SomeMethod()
        {
            // This is indirectly accessing a private implemented in the class
            // this derives from, but existing inside this class.
            int numbery = this.ReturnANumber();
        }
    }
    public class Whatever
    {
        public void AMethod(DClass someDClass)
        {
            int thisIsNumberFive = someDClass.ReturnANumber();
        }
    }
