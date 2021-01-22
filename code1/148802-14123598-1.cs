     function check() 
     {
                var validated = Page_ClientValidate();
                if (validated) {
                    __doPostBack('<%=bur.ClientID%>','');             
                    parent.$.fancybox.close();                                                       
                    return true;
                }
                else 
                {
                    return false;
                }
     }
    
    
    
     <asp:Button ID="bur" runat="server" Text="ser"  
                OnClientClick="check()"   />
    
    
    protected void bur_Click(object sender,Eventargs e)
    { //put breakpoint here.
    
    }
