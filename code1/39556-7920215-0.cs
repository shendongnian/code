        void Register()
        {
            var super = new SuperHandler();
            //not valid syntax:
            super.HandleEvent(MyEvent1);
            super.HandleEvent(MyEvent2);
            super.HandleEvent(MyEvent3);
            super.HandleEvent(MyEvent4);
        }
  
