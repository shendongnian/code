    void DoSomething()
    {
        try
        {
            /*
             * Do Something Useful.
             */ 
            CheckValue("Hello");
        }
        catch (InvalidDataException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    private void CheckValue(string inpXMLString)
    {
        if (inpXMLString != AppChildNode.InnerText)
            throw new InvalidDataException("The entered value" + " " + inpXMLString + " " + "doesnot exist");
    }
