    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class MyForm : Form {
        Button btn;
        ListBox lst;
        TextBox tb;
        const int MaxTries = 3, MaxNumber = 10;
        int targetNumber, guessCount = 0;
        public MyForm() {
            targetNumber = new Random().Next(1, MaxNumber + 1);
            Text = "Guess a number";
            Icon = SystemIcons.Question;
            Controls.Add(lst = new ListBox {Dock=DockStyle.Fill});
            Controls.Add(btn = new Button {Text="Guess",Dock=DockStyle.Top});
            Controls.Add(tb = new TextBox {Dock=DockStyle.Top});
            btn.Click += btn_Click;
        }
    
        void  btn_Click(object sender, EventArgs e) {
     	    int userNumber;
            if (int.TryParse(tb.Text.Trim(), out userNumber)) {
                if (userNumber < 1 || userNumber > MaxNumber) {
                    lst.Items.Add("Did I mention... between 1 and " + MaxNumber);
                } else {
                    if (userNumber == targetNumber) {
                        lst.Items.Add("Well done! You guessed well");
                        btn.Enabled = false; // all done
                    } else {
                        lst.Items.Add(targetNumber < userNumber
                            ? "Try a bit lower" : @"It is bigger than that");
                        if (++guessCount >= MaxTries) {
                            btn.Enabled = false;
                            lst.Items.Add("Oops, should have picked more wisely");
                        }
                    }
                }
            } else {
                lst.Items.Add("Nice; now give me a number");
            }
        }
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
    }
