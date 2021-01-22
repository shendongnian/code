    public const int CB_GETDROPPEDSTATE = 0x0157;
    public static bool GetDroppedDown(ComboBox comboBox)
    {
    	Message comboBoxDroppedMsg = Message.Create(comboBox.Handle, CB_GETDROPPEDSTATE, IntPtr.Zero, IntPtr.Zero);
    
    	MessageWindow.SendMessage(ref comboBoxDroppedMsg);
    
    	return comboBoxDroppedMsg.Result != IntPtr.Zero;
    }
