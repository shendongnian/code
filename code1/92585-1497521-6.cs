        private static readonly object UnitChangedKey = new object();
        public event EventHandler UnitChanged
        {
            add {Events.AddHandler(UnitChangedKey, value);}
            remove {Events.AddHandler(UnitChangedKey, value);}
        }
        ...
        EventHandler handler = (EventHandler)Events[UnitChangedKey];
        if (handler != null) handler(this, EventArgs.Empty);
