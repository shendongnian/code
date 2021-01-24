    int i;
    private void printDocTicket_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        float point = 60;  
        
        e.Graphics.DrawString(DGV["Sym3", x].Value.ToString(), new Font("Courier New", 30), Brushes.Black, 60 , point );
        e.HasMorePages = true;
        i++;
        
        if(i == DGV.Rows.Count)
        {
            e.HasMorePages = false;
        }
    }
