            Results = new DataSet();
            var adapter = new SqlDataAdapter {SelectCommand = Command};
            adapter.Fill(Results);
            Connection.Close();
            RETURN_VALUE = Convert.ToInt32(Command.Parameters["@RETURN_VALUE"].Value);
        }
        catch (SqlException ex)
        {
                Console.Error.WriteLine(ex.StackTrace);
        }
