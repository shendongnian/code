    class MyClass {
        private static MyClass _instance;
        private static List<string> _list;
        private static bool IsRecording;
        public static void StartRecording()
        {
            _list = new List<string>();
            IsRecording = true;
        }
        public static IEnumerable<string> StopRecording()
        {
            IsRecording = false;
            return new List<string>(_list).AsReadOnly();
        }
        private static MyClass GetInstance() // make this private, not public
        {   return _instance;    }
        public static void DoSomething()
        {
            // use inst internally to the function to get access to instance variables
            MyClass inst = GetInstance();
        }
    }
