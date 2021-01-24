    private void button1_Click(object sender, EventArgs e)
    {
    	this.Hide();
    	var nextForm = new Form1();
    	nextForm.FormClosing += (s,e) => {
    		nextForm.Dispose(); // not always needed, but calling it doesn't hurt. It ensures the "nextForm" variable gets disposed, acts just like "using" statement.
    		this.Show();
    	};
    	try{
    		nextForm.Show();
    	}
    	catch(Exception e){
    		//manage your exception here
    	}
    	
    	
    }
