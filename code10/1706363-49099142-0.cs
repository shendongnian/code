    static List<Teacher> teachers = new List<teachers>();
    public void AddTeacher()
    {
        Teacher x = new Teacher(textBox1.Text,textBox2.Text, int.Parse(textBox3.Text), textBox4.Text, n);
        comboBox1.DataSource = null;
        comboBox1.DataSource = teachers;
        comboBox1.DisplayMember = "Name";
    }
