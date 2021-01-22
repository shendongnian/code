            public void Initialize()
            {
            foreach (DEVICE_ACTION_REQUEST Action in Enum.GetValues(typeof(DEVICE_ACTION_REQUEST)))
                EventDispatcher<DEVICE_ACTION_REQUEST>.CreateEvent(Action);
            }
