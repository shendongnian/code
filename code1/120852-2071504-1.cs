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
            
            // E.g. that there are 2 changes - properties Id and Name changed once each: 
            Assert.AreEqual(2, _eventCounter); 
            Assert.AreEqual(1, _propertiesChanged["Id"]);
            Assert.AreEqual(1, _propertiesChanged["Name"]);
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
