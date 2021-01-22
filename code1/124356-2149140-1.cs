        // delegate signature
        public delegate void addKVP(string sender, int value);
        // delegate instance
        public static event addKVP KeyValuePairAdded;
        // delegate run-time dispatcher
        public static void OnKVPAdded(string sender, int theInt)
        {
          if (KeyValuePairAdded != null)
          {
              KeyValuePairAdded(sender, theInt);
          }
        }
