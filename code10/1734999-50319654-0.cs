        private void btnCheckText_Click(object sender, EventArgs e)
        {
            answer = textBox1.Text;
            if (answer == "help")
            {
                MessageBox.Show("There is only 2 commands as of now and that is 'help' and 'program_speech' ");
            }
            else if (answer == "program_speech")
            {
                MessageBox.Show("Still currently under creation");
            }
            else
            {
                MessageBox.Show("Invalid Command. Please try again or type help for current available commands");
            }
        }
