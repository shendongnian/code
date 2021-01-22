    public static EventHandler<T> Wrap<T>(EventHandler<T> original,
        ISynchronizeInvoke synchronizingObject) where T : EventArgs
    {
        return (object sender, T args) =>
        {
            if (synchronizingObject.InvokeRequired)
            {
                synchronizingObject.Invoke(original, new object[] { sender, args });
            }
            else
            {
                original(sender, args);
            }
        };
    }
