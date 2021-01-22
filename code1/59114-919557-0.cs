        public class MyClass {
        private string _MyProperty = "TEST";
        public string MyProperty {
            get { return _MyProperty; }
            set { _MyProperty = value; }
        }
        public void GetName() {
            Type t = this.GetType();
            PropertyInfo[] pInfos = t.GetProperties();
            foreach(PropertyInfo x in pInfos)
                Console.WriteLine(x.Name);
            
        }
    }
 
