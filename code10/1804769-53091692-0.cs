    private void chart1_Customize(object sender, EventArgs e)
        {
            // Set X axis interval to 1, label will be centered (between 0.5 and 1.5)
            chart1.ChartAreas[0].AxisX.Interval = 1;
            double startOffset = 0.5;
            double endOffset = 1.5;
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            // Cycle through chart Datapoints in first serie
            foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint pt in chart1.Series[0].Points)
            {
                // First get the dataset used for the chart (from its bindingsource)
                DataSet dsSales = (DataSet)bsViewVentesParUtilisateurSignsMoisCourant.DataSource;
                // Second get the datatable from that dataset based on the datamember 
                // property of the bindingsource
                DataTable dtSales = (DataTable)dsSales.Tables[bsViewVentesParUtilisateurSignsMoisCourant.DataMember];
                // Get a dataview and filter its result based on the current point's XValue
                DataView dv = new DataView(dtSales);
                dv.RowFilter = "idEmploye=" + pt.XValue.ToString();
                // Get the "Salesperson" (or "Vendeur") column value from the first result
                // (other rows will have the same value but row 0 is safe)
                string firstname = dv.ToTable().Rows[0].Field<string>("Vendeur").ToString();
                // Create new customlabel and add it to the X axis
                CustomLabel salespersonLabel = new CustomLabel(startOffset, endOffset, firstname, 0, LabelMarkStyle.None);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(salespersonLabel);
                startOffset += 1;
                endOffset += 1;
            }
        }
