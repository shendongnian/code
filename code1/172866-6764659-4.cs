    // inside Form class ...
    private readonly KeyBordHook _keyBordHook = new KeyBordHook();
    private void InitKeyHook()
    {
    	_keyBordHook.OnKeyPressEvent += new KeyPressEventHandler(_KeyBordHook_OnKeyPressEvent);
    	_keyBordHook.Start();
    }
    	
    void _KeyBordHook_OnKeyPressEvent(object sender, KeyPressEventArgs e)
    {
    	if (e.KeyChar == Convert.ToChar(Keys.Escape))
    		WindowHelper.CloseWindowIfActive("Flash");
    }
    public void StartKeyListening()
    {
    	InitKeyHook();
    }
    
    public void StopKeyListening()
    {
    	_keyBordHook.Stop();
    }
