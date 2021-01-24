     TimeSpan duration = new TimeSpan();
     foreach (DataGridViewRow row in attenViewGrid.Rows)
     {
         string start = row.Cells[5].Value.ToString();
         string end = row.Cells[6].Value.ToString();
    
         if(DateTime.Parse(end).Compare(DateTime.Parse(start)) < 0) 
             duration += Timespan.FromDays(1);
    
         duration += DateTime.Parse(end).Subtract(DateTime.Parse(start));
      }
