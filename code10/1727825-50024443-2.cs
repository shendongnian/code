          private void btnFindGrade_Click(object sender, EventArgs e) {
            int myGrade = Convert.ToInt32(txtScore.Text);
            Test found = allGrades
              .OfType<Test>()
              .FirstOrDefault(item => item.grade == myGrade);
            if (found != null) {
              MessageBox.Show($"score: {found.score} grade: {found.Grade}");
            }
            else 
              MessageBox.Show($"Not found");
          }
