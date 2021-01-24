    if (usernames.Contains(metroTextBox2.Text) && passwords.Contains(metroTextBox1.Text) && Array.IndexOf(usernames, metroTextBox2.Text) == Array.IndexOf(passwords, metroTextBox1.Text))
            {
                Image img = Properties.Resources.Ok_48px; // Right'as
                metroTextBox2.Icon = img;
                // Kitas image
                metroTextBox1.Icon = Properties.Resources.Ok_48px;
            }
            else
            {
                // new wrong().Show();
                Image img = Properties.Resources.Cancel_48px; // Wrong'as
                metroTextBox2.Icon = img;
                //Kitas image
                metroTextBox1.Icon = Properties.Resources.Cancel_48px;
            }
           
