    try
    {
        string s = "hu";
        int i = int.Parse(s);
    }
    catch (Exception ex)
    {
        string s = "hu";
        int i = int.Parse(s);
        throw new Exception();
    }
    finally
    {
        MessageBox.Show("hi");
    }
