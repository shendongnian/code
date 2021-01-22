    private void button1_Click( object sender, EventArgs e ) {
    	try {
    		CallMe(234);
    	} catch (Exception ex) {
    		label1.Text = ex.Message.ToString();
    	}
    }
    private void CallMe( Int32 x ) {
    	CallMe(x);
    }
