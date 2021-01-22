    public class MyClass : INotifyPropertyChanged { ... }
    
    [TestFixture]
    public class MyTestClass
    {
        private readonly Dictionary<string, int> _propertiesChanged = new Dictionary<string, int>();
        private int _eventCounter; 
        
        [Test]
        public void SomeTest()
        {
            // First attach to the object
            var myObj = new MyClass(); 
            myObj.PropertyChanged += SomeCustomEventHandler;
            myObj.DoSomething(); 
            // And here you can check whether the object updated properties - and which - 
            // dependent on what you do in SomeCustomEventHandler. 
            ... 
        }
        // In this example - counting total number of changes - and count pr property. 
        // Do whatever suits you. 
        private void SomeCustomEventHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var property = e.PropertyName;
            if (_propertiesChanged.ContainsKey(property))
                _propertiesChanged[property]++;
            else
                _propertiesChanged[property] = 1;
            
            _eventCounter++;
        }
    }
