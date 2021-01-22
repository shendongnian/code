        public static event VoidEventHandler<SomeObject, List<OtherObject>> SomethingUpdated;
        public static void OnSomethingUpdated(SomeObject sender, List<OtherObject> associations)
        {
            if (SomethingUpdated != null)
            {
                SomethingUpdated(sender, associations);
            }
        }
        // ...
        MyClass.SomethingUpdated+= new VoidEventHandler<SomeObject, List<OtherObject>>(MyClass_SomethingUpdated);
        // ...
        void MyClass_SomethingUpdated(SomeObject param1, List<OtherObject> param2)
        {
          //do something
        }
