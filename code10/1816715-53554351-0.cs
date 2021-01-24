    public MyConstructor()
    {
        S1.Toggled += S1_Toggled;
    }
    
    void S1_Toggled(object sender, ToggledEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine(String.Format("Switch is now {0}", e.Value));
    }
