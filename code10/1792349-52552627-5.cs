    List<Student> _students = new List<Student>();
    private void btnAdd_Click(object sender, EventArgs e)
    {
        _students.Add(new Student(txtName.Text, (byte)nudAge.Value));
    }
