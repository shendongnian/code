    <script runat="server">
        private void Page_Load(object sender, System.EventArgs e){
            
            string test = Request.QueryString["foo"];
    
            //Convert the query string you captured to an int and store it in an int.
            int intTest = Convert.ToInt32(test); 
    
            Response.Write(intTest.GetType() + "<br>" + intTest);   
        }
    </script>
