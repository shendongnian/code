    class YourClass
    {    
        //data members ...
        public void OnKeyboardPress(object sender, EventArgs args)
        {
            //handle your logic capturing the state here
        }
    }
    //elsewhere
    someControl.KeyPress += new KeyPressDelegate(yourClassInstance.OnKeyboardPress);
    
