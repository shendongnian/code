    void DoStuff()
    {
        string path = @"C:\Users\sam\Documents\GCProg\testReadFile.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            while (keepGoing) // Whatever logic you have
            {
                string invoice = InvoiceNumberFunc(sr);
                // Use invoice
            }
        }
    }
    string InvoiceNumberFunc(TextReader reader)
    {
        string invoiceNumber;
        try
        {
            invoiceNumber = reader.ReadLine();
        }
        catch (Exception exp)
        {
            Console.WriteLine("The process failed: {0}", exp.ToString());
        }
        return invoiceNumber;
    }
