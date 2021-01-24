        try
        {
        dateTimePicker2.Value = new DateTime(dateTimePicker1.Value.Year - 1, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
        }
        catch
        {
         if(dateTimePicker1.Value.Month==2 && dateTimePicker1.Value.Day==29)
         {
           dateTimePicker2.Value = new DateTime(dateTimePicker1.Value.Year - 1, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day-1);
         }
      }
