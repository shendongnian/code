    var t1 = new Thread(TestMethod);
    t1.Name = "abc";
    t1.Start();
    lock (t1)
    {
        t1.GetType().
            GetField("m_Name", BindingFlags.Instance | BindingFlags.NonPublic).
            SetValue(t1, null);
        t1.Name = "def";
    }
