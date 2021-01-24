    // Connects to the website
    var webRequest = WebRequest.Create("http://yourwebsite.com/programLogin.php?username=" + textBox1.Text);
    using (var response = webRequest.GetResponse())
    using (var content = response.GetResponseStream())
    using (var reader = new StreamReader(content))
    {
        // This gets all of the info given out by the website
    var info = reader.ReadToEnd();
        // Comparing to expected outputs
        if (info == "User found in the database")
        {
        	MessageBox.Show("Username Exists", "Login Form");
        }
        else if (info == "Username not found")
        {
        	MessageBox.Show("Username Not Found", "Login Form");
        }
        else
        {
        	// This will most likely only thow if the website is down OR if there is a HTTP error 500 OR unsuccessful login to the database
        	MessageBox.Show("Unknown Error", "Login Form");
        }
    }
