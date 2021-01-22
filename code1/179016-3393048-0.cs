    protected IEnumerable<Employee> GetEmployee(string empNo)
    {
        try
        {
            DataClasses1DataContext dataClass1 = new DataClasses1DataContext();
            // I tried to cast it to DataTable, but it doesn't work...
            return dataClass1.findEmployeeByID(empNo);
        }
        catch (Exception x)
        {
            MessageBox.Show(x.GetBaseException().ToString(), "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        finally
        {
            pl.MySQLConn.Close();
        }
    }
