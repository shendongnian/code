    confirmation.Click += (sender, e) => {
        if (textBox.Text == output) // Password is correct.
        {
            isCorrect = true;
            Pprompt.Close();
        }
        else
        {
            isCorrect = false;
            textBox.Text = "";
            tryCount++;
            if (tryCount == 3)
            {
                MessageBox.Show("Access Denied.");
                Pprompt.Close();
            }
        }
    }
