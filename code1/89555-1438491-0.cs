    /// <summary>
    /// Delegate used to handle events with a strongly-typed sender.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender.</typeparam>
    /// <typeparam name="TArgs">The type of the event arguments.</typeparam>
    /// <param name="sender">The control where the event originated.</param>
    /// <param name="e">Any event arguments.</param>
    public delegate void EventHandler<TSender, TArgs>(TSender sender, TArgs e) where TArgs : EventArgs;
