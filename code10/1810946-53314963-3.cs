        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("id", typeof(String));
                dt.Columns.Add(dc);
                dc = new DataColumn("TicketStatus", typeof(TicketStatuses));
                dt.Columns.Add(dc);
                DataRow dr;
                //Adding test data of 6 rows
                for (int i = 0; i <= 6; i++)
                {
                    dr = dt.NewRow();
                    
                    dr[0] = i + 2; //Just a random column value - Could be anything here.
                    dt.Rows.Add(dr);
                }
                // Setting column values for Column "TicketStatus" of our choice.
                dt.Rows[0][1] = TicketStatuses.Unpaid;
                dt.Rows[1][1] = TicketStatuses.Cancelled;
                dt.Rows[2][1] = TicketStatuses.Cancelled;
                dt.Rows[3][1] = TicketStatuses.Issued;
                dt.Rows[4][1] = TicketStatuses.Attended;
                dt.Rows[5][1] = TicketStatuses.Attended;
                dt.Rows[6][1] = TicketStatuses.Issued;
                //sorting datarows
                DataRow[] dataRows = dt.Select().OrderBy(u => u["TicketStatus"]).ToArray();
                DataTable sortedDatatable = dataRows.CopyToDataTable();
            }
        }
