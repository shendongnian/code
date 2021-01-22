        public class ListAcc 
        { 
            public static List<Account> UserList = new List<Account>();
        } 
 
        private void button1_Click(object sender, EventArgs e) 
        { 
            Account acc = new Account(); 
            acc.Username = textBox1.Text; 
            acc.Password = textBox2.Text; 
            ListAcc.UserList.Add(acc); 
        } 
 
        private void button2_Click(object sender, EventArgs e)  //frm2 
        { 
            string p1 = ListAcc.UserList[0].Username; // null ->error 
            string p2 = ListAcc.UserList[0].Password; // null ->error 
        } 
