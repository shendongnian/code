    public class BusinessLogic 
    {
        private BusinessLogicSubClass blsc = null;
    
        public BusinessLogic() {}
        public void Initialize()
        {
            blsc = new BusinessLogicSubClass(this);
        }
    }
    
    public class Implementor
    {
        public void SomeFunction()
        {
            BusinessLogic bl = new BusinessLogic();
            bl.Initialize();
        }
    }
