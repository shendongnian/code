            try
            {
                e.Row.Cells[22].Value = false;
            }
            catch (Exception ex)
            {
                mainForm.staticvar.logger.Write(ex);
            }
        }
