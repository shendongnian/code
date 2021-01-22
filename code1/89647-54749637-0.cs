     /// <summary>
        /// retrieve the document types from the database
        /// </summary>
        /// <returns></returns>
        private SelectList FillDocumentTypes()
        {
            SqlCommand command = null;
            SqlConnection _sqlcon = null;
            SelectList result = null;
            try
            {
                _sqlcon = new SqlConnection(connectionString);
                string commandText = string.Concat("select Code, [Description] from tblC2scDocumentTypeCodes");
                command = new SqlCommand(commandText, _sqlcon);
                _sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, _sqlcon);
                DataTable dataTable = new DataTable();
                dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(dataTable);
                //populate selectlist with DataTable dt
                result = new SelectList(dataTable.AsDataView(), "Code", "Description");
                _sqlcon.Close();
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
              }
            finally
            {
                command.Dispose();
                _sqlcon.Dispose();
            }
        }
