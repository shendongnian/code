        </div>
            <script>
                        function validate() {
                            try {
            
                            var username = document.getElementById("<%=txtUserName.ClientID%>").value;
                            var password = document.getElementById("<%=txtPWD.ClientID%>").value;
            
                                if (username == "" && password == "")
                                    alert("Enter Username and Passowrd");
                                else {
                                    if (username == "")
                                        alert("Enter Username");
                                    else if (password == "")
                                        alert("Enter Password");
                                }
                                    
                            }
            
                        catch (err) {
                        }
                    }
                    </script>
    </form>
              
    
      
