    try
    {
      validProject(txtAddProjectID.Text);
    }
    catch (ArgumentException e)
    {
      addErr.Text = "";
      addErr.Text = e.Message;
    }
    private static void validProject(object text)
    {
      throw new ArgumentException($"Invalid Project ID.{text}");
    }
