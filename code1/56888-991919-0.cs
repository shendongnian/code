    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <script runat="server">
        
        [System.Web.Services.WebMethod]
        public static String Msg()
        {
            String userName = "Chalkey";
            return userName;
        }
    </script>
    <script type="text/javascript">
        PageMethods.Msg(OnSucceed);
    
        function OnSucceed(result)
        {
            alert(result);
        }
    </script>
