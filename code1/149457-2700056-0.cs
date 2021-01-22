           public class Account
           {
               public string Username;
               public string Password;
           }
           public class ListAcc
           {
               public static int count = 0;
               private static List<Account> UserList;
               public static List<Account> Data()
               {
                    return UserList;
               }
               ListAcc()
               {
                    UserList = new List<Account>();
                    UserList.Add(new Account() { Username = "x", Password = "y" });
               }
           }
           public partial class frmForm1 : Form  // Form1
           {
                public static ListAcc;
           }
           public partial class frmForm2 : Form  // Form2
           {
               private void button2_Click(object sender, EventArgs e)
               {
                   string m = frmForm1.ListAcc.Data()[0].Username;
               }
           }
