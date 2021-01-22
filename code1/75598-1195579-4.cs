    MyFactory.Current = new MyFactory(parameters);
    
    public partial class MyEntity
    {
        public MyEntity()
        {
            _calcStrategy = MyFactory.Current.ProvideCalculator(this);
        }
    }
