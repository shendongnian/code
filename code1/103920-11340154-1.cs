        System.Text.StringBuilder objSB = new System.Text.StringBuilder();
        //Append values
        objSB.Append("This is .Net Blog.");
        objSB.Append("You can get latest C# Tips over here.");
        //Display on screen
        Response.Write(objSB.ToString());
        Response.Write("<br/><br/>");
        //Clear object using Clear method
        objSB.Clear();
        //Append another values
        objSB.Append("This blog is very useful for .Net Beginners");
        Response.Write("After Clear<br/><br/>");
        //Display on screen
        Response.Write(objSB.ToString());
