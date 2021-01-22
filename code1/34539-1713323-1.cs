    //Here ilv is the List, who's column are to be resized
    //Get the current column widths
    ArrayList widths = new ArrayList();
    foreach (ColumnHeader ch in ilv.Columns)
    {
        widths.Add(ch.Width);
    }
    //Get the total width of all the columns
    int total_width = 0;
    for (int i = 0; i < widths.Count; i++)
    {
         total_width += (int)widths[i];
    }
    //Calculate percentages and resize the columns.
    for (int i = 0; i < widths.Count; i++)
    {
        double c_width = (int)widths[i];
        double pect = (c_width / total_width);
        //get the new width, leave out 25 pixels for scrollbar
        double n_width = (ilv.Width - 25) * pect;
        n_width = Math.Round(n_width, 0);
        //MessageBox.Show(c_width + " - " + pect + " - " + n_width);
        ilv.Columns[i].Width = (int)n_width;                    
    }
