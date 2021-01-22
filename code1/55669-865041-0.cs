    delegate void KeyPadSubscription (char keyPressed);
    List<KeyPadSubscription> subscriptions;
    
    void KeyPress (object sender, KeyPressArgs e)
    {
       foreach (KeyPadSubscription sub in subscriptions)
            sub (e.CharCode)
    }
    
    void Subscribe(KeyPadSubscription s)
    {
        subscriptions.Add(s);
    }
    
    void Unsubscribe(KeyPadSubscription s)
    {
        subscriptions.Remove(s);
    }
