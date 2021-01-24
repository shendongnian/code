        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Age = 21;
            s.FirstName = "George";
            s.LastName = "Washington";
            s.StudentNumber = "S54";
            s.StudentAddress = new Address("Park Street","Houston", "USA" );
            MessageBox.Show(s.ToString());
        }
