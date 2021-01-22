    private void SparePanel_Paint(object sender, PaintEventArgs e)
    {
       using (SolidBrush empBrush = new SolidBrush(Color.Red))
       {
          int y = 0;
          foreach (Employee employee in EmployeeList)
          {
             e.Graphics.DrawString(employee.Name, ((Panel)sender).Font, empBrush, 0, y);
             y += 10;
          }
       }
    }
