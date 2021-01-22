    private void dataGridViewEpizode_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[22].Value = false;
            }
            catch (Exception ex)
            {
                mainForm.staticvar.logger.Write(ex);
            }
        }
