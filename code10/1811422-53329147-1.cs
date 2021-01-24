    DataTable Test = new DataTable();
    Test.Columns.Add("Text", typeof(string));
    Test.Columns.Add("Advice", typeof(string));
    Test.Columns.Add("Choice One", typeof(string));
    Test.Columns.Add("Choice Two", typeof(string));
    Test.Columns.Add("Choice Id (Determines Answer)", typeof(int));
    Test.Rows.Add(1, "2x2", "Count with your fingers", "4", "9", 1);;
    dgvQuestions.DataSource = Test;
