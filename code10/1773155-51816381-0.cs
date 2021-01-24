    var SCindex = Properties.Settings.Default.MessageStringCollection.IndexOf(Message);
    if (SCindex > 0)
    {
        Properties.Settings.Default.MessageStringCollection.Remove(String.Format("{0}", Message));
        Properties.Settings.Default.MessageStringCollection.Insert(SCindex - 1, Message);
        Properties.Settings.Default.Save();
    }
