    [System.Web.Services.WebMethod]
        public static void GetData()
        {
            MessageBox.Show("Calling From Client Side");
            //Your Logic comes here
        }
    
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
    <body>
        <form id="form1" runat="server">
        <script type="text/javascript">
            function CallingServerSideFunction() {
                PageMethods.GetData();
            }
        </script>
        </form>
    </body>
