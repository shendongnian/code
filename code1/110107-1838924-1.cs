    try
    {
        if (someStatement)
        {
            //...
            if (SomeOtherStatement)
            {
                //..., possibly more cases like this
            }
            else
            {
                throw new MyException();
                //would otherwise repeat
                //the MessageBox.Show here
            }
        }
    }
    catch(MyException e)
    {
        MessageBox.Show(e.Message);
        // log the exception, if necessary
    }
    finally
    {
        // tidy up
    }
