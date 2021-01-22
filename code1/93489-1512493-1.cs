    namespace test {
        public delegate void TestCompletedEventHandler(object sender, 
        TestCompletedEventArgs e);
    
        public class Manager {
            CarList m_carlist = null;
    
            public CarList Cars {
                get { return m_carlist; }
                set { m_carlist = value; }
            }
    
            public Manager() {
                Cars = new CarList(this);
            }
    
            public void Report(bool successful) {
                //...
            }
        }
    
        public class CarList : List<Car> {
            protected readonly Manager m_manager = null;
    		protected List<Action<object, TestCompletedEventArgs>> delegatesList = new List<Action<object, TestCompletedEventArgs>>();
    
            public Manager Manager {
                get { return m_manager; }
            }
    
            public CarList(Manager manager) {
                m_manager = manager;
            }
    
            public void Test() {
                foreach(Car car in this) {
                    bool ret = car.Test();
                    manager.Report(ret);
                }
            }
            public void Add(TestCompletedEventHandler e) {
                foreach (Car car in this) {
                    car.OnTestCompleted += e;
                }
    			delegatesList.Add(e);
            }
            public void Add(Car car) {
    		foreach(Action a in delegatesList)
    		{
    		    car.OnTestCompleted += a;
    		}
                base.Add(car);
            }
        }
    
        public class Car {
            protected internal event TestCompletedEventHandler OnTestCompleted = null;
    
            public bool Test() {
                //...
                if (OnTestCompleted != null) OnTestCompleted(this, new TestCompletedEventArgs());
            }
        }
    
        public class TestCompletedEventArgs : EventArgs {
            //...
        }
    }
    
    using test;
    Manager manager = new Manager();
    Manager.Cars.Add(new Car());
    manager.Cars.Add(new Car());
    manager.Cars.Add(new Car());
    manager.Cars.Add((sender, args) => 
    {
        //do whatever...
    })
    manager.Cars.Test();
    manager.Cars.Add(new Car());
