    var t1 = new Thread(TestMethod); 
    t1.Name = "abc"; 
    t1.Start(); 
    lock (t1) 
    {
      t1.GetType().
          GetField("m_Name", BindingFlags.Instance | BindingFlags.NonPublic).
          SetValue(t1, "def"); 
      t1.GetType().
          GetMethod("InformThreadNameChangeEx", BindingFlags.NonPublic | 
              BindingFlags.Static).
          Invoke(t1, new object[] { t1, t1.Name});
    }
