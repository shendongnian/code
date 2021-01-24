    public ArrayList ReadCLientDetailsFromFile(string clientCsvfileName)
    {
        //some code
        if (commas < 3 || commas >4)
        {
            MessageBox.Show("There are more than 4 values on line "+ lineCount + "\nThe 
            Operation will abort");
            throw new ArgumentOutOfRangeException("There is more than 4 values on line "+ 
            lineCount); //exit the code here
        }
        //rest of the code
    }
