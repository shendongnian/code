    <title></title>
    <script>
     function GetUserValue() {
       var newlength = prompt("Please Enter New Length", "");
       if (newlength != null && newlength != "") {
         document.getElementById("<%=hdnLengthInput.ClientID%>").value = newlength;
         return true;
      }
      else
      return false;
     }
    </script>
    <div>
     <asp:HiddenField runat="server" ID="hdnLengthInput" />
    </div>
    And Then in the .CS file:
    protected void lnkButton_Click(object sender, EventArgs e)
        {
            Response.Write(hdnLengthInput.Value);
            using (var connection3 = new 
    SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM Categories WHERE 
    Length = '" + hdnLengthInput.Value + "'", connection);
                Int32 count = Convert.ToInt32(comm.ExecuteScalar());
                if (count == 0)
                    using (var cmd1 = new SqlCommand("INSERT INTO Categories(Length) 
    VALUES('" + hdnLengthInput.Value + "');", connection3))
                    {
                        connection3.Open();
                        cmd1.ExecuteNonQuery();
                        connection3.Close();
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                connection.Close();
            }
         }
