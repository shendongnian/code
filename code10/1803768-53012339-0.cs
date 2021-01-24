    private void TestTryCatchFinally()
    {
        try
        {
            Debug.WriteLine("Start Outer Try");
            try
            {
                Debug.WriteLine("Start Inner Try");
                throw new Exception("Exception from inner try");
                Debug.WriteLine("End of Inner Try - never reaced");
            }
            //remove this catch block for second 
            catch (Exception)
            {
                Debug.WriteLine("In inner catch");
            }
            //end of code to remove
            finally
            {
                Debug.WriteLine("In Inner Finally");
            }
        }
        catch (Exception)
        {
            Debug.WriteLine("In outer catch");
        }
        finally
        {
            Debug.WriteLine("In outer finally");
        }
    }
