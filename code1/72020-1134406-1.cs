    CustomEvent myEvent;
    public event EventHandler MyEvent {
        add {
            if (value == null) throw new ArgumentNullException("value");
            var customHandler = value.Target as ICustomEvent;
            if (customHandler != null)
                myEvent = myEvent.Combine(customHandler);
            else
                myEvent = myEvent.Combine(value);   //An ordinary delegate
        }
        remove {
            //Similar code
        }
    }
