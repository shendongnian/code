        public delegate void MessageProcessor<T>(T msg) where T : IExternalizable;
        virtual public void OnRecivedMessage(IExternalizable msg)
        {
            Type type = msg.GetType();
            ArrayList list = processors.Get(type);
            if (list != null)
            {
                object[] args = new object[]{msg};
                for (int i = list.Count - 1; i >= 0; --i)
                {
                    Delegate e = (Delegate)list[i];
                    e.Method.Invoke(e.Target, args);
                }
            }
        }
