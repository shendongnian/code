            private void textBox1_Leave(object sender, EventArgs e)
            {
                DataClasses1DataContext linqToSqlDataContext = new DataClasses1DataContext();
                if (linqToSqlDataContext.employees.Any(x => x.Name == textBox1.Text))
                {
                    //move focus to surname text box control as the name already exists in DB
                    textBox2.Focus();
                }
                else
                {
                    //add a new entity into database for the name entered by the user
                    linqToSqlDataContext.employees.Attach(new employee { Name = textBox1.Text });
                    linqToSqlDataContext.SubmitChanges();
    
                }
            }
