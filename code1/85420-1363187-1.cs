    public static class MyClass 
    {
        private static List<string> _myList = new List<string>;
        private static bool _record; 
    
        public static void StartRecording()
        {
            lock(_myList)   // lock on the list
            {
               _myList.Clear();
               _record = true;
            }
        }
    
        public static IEnumerable<string> StopRecording()
        {
            lock(_myList)
            {
              _record = false;
              // Return a Read-Only copy of the list data
              var result = new List<string>(_myList).AsReadOnly();
              _myList.Clear();
              return result;
            }
        }
    
        public static void DoSomething()
        {
            lock(_myList)
            {
              if(_record) _myList.Add("Test");
            }
            // More, but unrelated actions
        }
    }
