try
{
	// code here which throws exception
}
catch (Exception ex) when(ex.Message.Contains("Access Denied"))
{
	MessageBox.Show("Sorry, Access Denied", "This is a polite error message");
}
