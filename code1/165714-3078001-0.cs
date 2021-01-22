    public class MyClass {
        public string MyString { get; private set; }
        public int MyInt { get; private set; }
        public double MyDouble { get; private set; }
    
        public MyClass(string myString, int myInt, double myDouble){
            MyString = myString;
            MyInt = myInt;
            MyDouble = myDouble;
        }
    }
    
    public class SomeOtherClass{
        public List<MyClass> m_Instances = new List<MyClass>();
    
        public void FillList(){
            //Instantiate 3 items, and add to the list
            m_Instances.Add(new MyClass("1", 2, 3d));
            m_Instances.Add(new MyClass("4", 5, 6d));
            m_Instances.Add(new MyClass("7", 8, 9d));
        }
    
        public void RemoveFirst(){
            //Remove the first one. As long as the removed item has no
            //other instances, the Garbage Collector will (in its own time)
            //destroy that unused object, and reclaim the memory.
            m_Instances.RemoveAt(0);
        }
    }
