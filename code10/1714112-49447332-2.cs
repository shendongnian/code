    void Button1_click()
    {
       using (Form2 form2 = new Form2())
       {
          if (form2.DialogResult == DialogResult.OK)
          {
             var chart = form2.CreateChart();
             chart.Parent = YourPanel;
          }
       }
    }
