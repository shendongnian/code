    public void WriteCustomers(string filePath, IEnumerable<Customer> customers)
        {
            try
            {
               // Code
            }
            catch (IOException e)
            {
                throw new IOException("Error in write customers", ex);
            }
        }
    public void WriteSomethingElse(string filePath, IEnumerable<Something> s)
        {
            try
            {
               // Code
            }
            catch (IOException e)
            {
                throw new IOException("Error in something else", ex);
            }
        }
