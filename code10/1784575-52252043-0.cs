    class WndWindow{
        BtnPopup_Click(object sender, EventArgs e){
            using(var popup = new WndPopup()){
                popup.BtnAddClick += Popup_BtnAddClick;
                popup.ShowDialog();
                popup.BtnAddClick -= Popup_BtnAddClick;
            }
        }
   
        Popup_BtnAddClick(object sender, EventArgs e){
            //Do something
        }
    }
    
    class WndPopup{
        public event EventHandler BtnAddClick;
    
        BtnAdd_Click(object sender, EventArgs e){
            //Do standard event handler code
            BtnAddClick?.Invoke(this, e);
        }
    }
