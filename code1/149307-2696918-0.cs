    public class ListAcc
    {
        // Don't put this in Data or you'll recreate it again and 
        // again when you call Data
        private static List<Account> UserList = new List<Account>();
    		
        // We'll pass in textBox1.Text via name parameter instead of 
        // referencing it directly which we can't
    	    public static void Data(string name)
    	    {
    	        //example of adding user account
    	        Account acc = new Account();
    	        acc.Username = name;
    	        UserList.Add(acc);
    	    }
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // We'll call Data and pass in textBox1.Text as our UserName
        ListAcc.Data(textBox1.Text);
    }
