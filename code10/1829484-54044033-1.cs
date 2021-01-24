    private void button4_Click(object sender, EventArgs e)
    {
        var students = new List<Student>();
        for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
        {
            students.Add(new Student
            {
                Name = $"student{i + 1}",
                Course1Score = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                Course2Score = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                FinalExamScore = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
            });
        }
        string results = string.Join(Environment.NewLine,
            students.Select(s => $"{s.Name} had an aggregate score of {s.AggregateScore}"));
        results += "\n\nThe average aggregated score is: " +
                    students.Average(student => student.AggregateScore);
        MessageBox.Show(results);
    }
