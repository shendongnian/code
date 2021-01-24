    private void button7_Click(object sender, EventArgs e){
        // I have no idea why you have enabled the button here, mate
        //Converting the quantity
        int qty = Convert.ToInt32(nudQuantity.Value);
        if((roSmallCup.Checked & rdoStraw.Checked) == true) {
            //triggers when the Inventory of strawberry is more than zero
            if( (InvStrawberry - (4 * qty)) > 0 ){
                InvStrawberry = InvStrawberry - (4 * qty);
            } else
            {
                button7.ENabled = false;
                MessageBox.Show("We are out of inventory,Sorry!");
            }
            label17.Text = Convert.ToString(InvStrawberry);
        }
    }
