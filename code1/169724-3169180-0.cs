        public void dispatchEvent<T>(T handler, EventArgs evt)
        {
            T temp = handler; // make a copy to be more thread-safe
            if (temp != null && temp is Delegate)
            {
                (temp as Delegate).Method.Invoke((temp as Delegate).Target, new Object[] { this, evt });
            }
        }
