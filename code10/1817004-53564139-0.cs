    private async void ReadBase()
        {
            await Task.Delay(500);
            using (sqlConnection = new SqlConnection(connectionString))
            {
                SqlDataReader dataReader = null;
                SqlCommand command = new SqlCommand("SELECT id, name, surname FROM myHumanity", sqlConnection);
                try
                {
                    await sqlConnection.OpenAsync();
                    dataReader = await command.ExecuteReaderAsync();
                    while (await dataReader.ReadAsync())
                    {
                        listbox.Items.Add(Convert.ToString(dataReader["id"]) + "    " + Convert.ToString(dataReader["name"]) + "    " + Convert.ToString(dataReader["surname"]));
                    }
                }
                catch (System.Threading.Tasks.TaskCanceledException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    dataReader?.Close();
                    sqlConnection?.Close();
                }
            }   
        }
