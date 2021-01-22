    class MyTextBox : TextBox
    {
        public overrides string Text{ 
            get{ return base.Text; }
            set{
                if( value == Text ) return;
                _updating = true;
                base.Text = value;
                _updating = false;
               }
        }
    }
