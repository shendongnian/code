    public void Page_Load(object sender, EventArgs e)
    {
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
           Response.Clear(); // dont want <html>.... etc stuff
           Response.Write("Hi from AJAX!");
        }
        else
        {
            // normal page stuff
        }
    }
