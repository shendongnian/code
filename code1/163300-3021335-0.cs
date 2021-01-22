    private void test_click(object sender, EventArgs e)
    {
        try
        {
            MessageBox.Show("hi");
            MessageBox.Show("worked ok");
        }
        catch(WheteverExceptionType ex)
        {
            MessageBox.Show("DID NOT WORK OK");
            // you can also access the properties of the thrown exception "ex" here...
            MessageBox.Show(ex.Message);
        }
    }
