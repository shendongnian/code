    public class Form1 : Form {
        public static Account UserAccount { get; set; }
        public Form1() {
            UserAccount = new Account();
        }
    }
    public Form3() {
        MessageBox.Show($"{Form1.UserAccount.Name}");
    }
