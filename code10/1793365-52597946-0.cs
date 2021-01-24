    private void DGV_PatientSessions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (DGV_PatientSessions.Columns[e.ColumnIndex].Name == "DGV_PatientSessions_Date")
        {
            string DateValue;
            DateTime DateFormated;
            DateValue = DGV_PatientSessions.CurrentRow.Cells["DGV_PatientSessions_Date"].Value.ToString();
            if (DateTime.TryParseExact(DateValue, "dd/MM/yyyy", new CultureInfo("ar-SY"), DateTimeStyles.None, out DateFormated))
            {
                MessageBox.Show("done");
            } 
    		else 
            {
    		    MessageBox.Show("value should match dd/MM/yyyy format");
    			e.Cancel = true; // The important part
    		}
        }
    }
