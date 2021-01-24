        //  MOVING CHART
            chart1.Invoke(new Action(()=>
        {
              if (chart1.Series[series_names[0]].Points.Count > nr_of_noints_graph)
              {
                   for (int i = 0; i < 3; i++)
                       chart1.Series[series_names[i]].Points.RemoveAt(0);
                   chart1.Series["average"].Points.RemoveAt(0);
                   chart1.ChartAreas[0].AxisX.Minimum = rows_nr - (nr_of_noints_graph - 1);
                   chart1.ChartAreas[0].AxisX.Maximum = rows_nr;
              }
         }
    )); 
    
                  
