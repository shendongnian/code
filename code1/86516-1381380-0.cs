    public class PythonDictionary {
        public string this[string index] {
            get { ... }
            set { ... }
        }
        public static implicit operator PythonDictionary(string value) {
            ...
        }
    }
    public void Example() {
        Dictionary<string, PythonDictionary> map = new Dictionary<string, PythonDictionary>();
        map["42"]["de"] = "foo";
        map["42"] = "bar";
    }
