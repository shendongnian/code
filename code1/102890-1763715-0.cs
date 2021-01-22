        private void button1_Click(object sender, EventArgs e)
        {
            ICommand command = ((Control)(sender)).Tag as ICommand;
            if (command != null)
            {
                command.Execute();
            }
        }
