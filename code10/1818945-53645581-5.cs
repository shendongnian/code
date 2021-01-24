    public bool TryReadCLientDetailsFromFile(ArrayList dest, string clientCsvfileName)
    {
        //some logic
        if (commas < 3 || commas >4)
            {
                MessageBox.Show("There is more than 4 values on line "+ lineCount + "\nThe Operation will abort");
                return false //exit the code here
            }
        //rest of the logic, sussess
        return true
    }
