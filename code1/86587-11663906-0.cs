        TextBox pvProductID = (TextBox)PreviousPage.FindControl("TextBox1");
        TextBox pvProductName = (TextBox)PreviousPage.FindControl("TextBox2");
        Label1.Text ="You came from: "+ PreviousPage.Title.ToString();        
        Label2.Text = "Product ID: " + pvProductID.Text.ToString();
        Label2.Text += "<br />Product Name: " + pvProductName.Text.ToString();
        string imageSource = "~/Images/" + pvProductID.Text + ".jpg";
        Image1.ImageUrl = imageSource;
        Image1.BorderWidth = 2;
        Image1.BorderColor = System.Drawing.Color.DodgerBlue;
    }
