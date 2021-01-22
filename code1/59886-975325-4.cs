    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TextBox tb;
            Button btn;
            ListBox lst;
            const int MaxTries = 3, MaxNumber = 10;
            int targetNumber = new Random().Next(1, MaxNumber + 1);
            using (Form form = new Form {
                Text = "Guess a number",
                Icon = SystemIcons.Question,
                Controls = {
                    (lst = new ListBox { Dock = DockStyle.Fill }),
                    (btn = new Button { Text = "Guess", Dock = DockStyle.Top }),
                    (tb = new TextBox { Dock = DockStyle.Top })
                } })
            {
                int guessCount = 0;
                
                btn.Click += delegate {
                    int userNumber;
                    if (int.TryParse(tb.Text.Trim(), out userNumber))
                    {
                        if (userNumber < 1 || userNumber > MaxNumber) {
                            lst.Items.Add("Did I mention... between 1 and " + MaxNumber);
                        } else {
                            if (userNumber == targetNumber) {
                                lst.Items.Add("Well done! You guessed well");
                                btn.Enabled = false; // all done
                            }
                            else {
                                lst.Items.Add(targetNumber < userNumber
                                    ? "Try a bit lower" : @"It is bigger than that");
                                if (++guessCount >= MaxTries)
                                {
                                    btn.Enabled = false;
                                    lst.Items.Add("Whoops, should have picked more wisely");
                                }
                            }
                        }
                    } else {
                        lst.Items.Add("Nice; now give me a number");
                    }
                };
                Application.Run(form);
            }
        }
    }
