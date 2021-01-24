    class WndWindow{
        BtnPaid_Click(object sender, EventArgs e){
            using(var paid = new PaidOutReason()){
                paid.BtnAddClick += Paid_BtnAddClick;
                paid.ShowDialog();
                paid.BtnAddClick -= Paid_BtnAddClick;
            }
        }
        
        Paid_BtnAddClick(object sender, EventArgs e){
            var popu = new PopUpBanks();
            popu.Show();
        }
    }
    
    class PaidOutReason{
        public event EventHandler BtnAddClick;
        
        BtnAdd_Click(object sender, EventArgs e){
            //Do standard event handler code
            
            BtnAddClick?.Invoke(this, e);
        }
    }
