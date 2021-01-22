        Main_Frm _main_Frm = null;
    
        private void Show_bt_Click(object sender, EventArgs e)
        {
            
            if (_main_Frm != null)
            {
                _main_Frm .BringToFront();
            }
            else
            {
                _main_Frm = new Comission_Frm();
                _main_Frm .Show();
            }
             //This condition used when you closed the form the form will disposed and when you reopen.
            if (_main_Frm .IsDisposed)
            {
                _main_Frm = new _Main_Frm ();
                _main_Frm .Show();
            }
       }
