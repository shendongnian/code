    private void AssertRaisesEvent(Action action, object obj, string eventName)
        {
            EventInfo eventInfo = obj.GetType().GetEvent(eventName);
            int raisedCount = 0;
            EventHandler handler = new EventHandler((sender, eventArgs) => { ++raisedCount; });
            eventInfo.AddEventHandler(obj, handler );
            action.Invoke();
            eventInfo.RemoveEventHandler(obj, handler);
            Assert.AreEqual(1, raisedCount);
        }
