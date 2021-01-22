    protected Employee CreateDT(string empNo)
        {
            
            try
            {
                DataClasses1DataContext dataClass1 = new DataClasses1DataContext();
                // I tried to cast it to DataTable, but it doesn't work...
                return dataClass1.findEmployeeByID(empNo).FirstOrDefault();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               //might need to dispose the context here
            }
            return null;
        }
