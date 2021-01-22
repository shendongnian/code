        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["key"] = ((GridView)sender).SelectedDataKey.Value;
        }
          
       <asp:GridView ID="Unnamed1" runat="server" 
                    onselectedindexchanged="Unnamed1_SelectedIndexChanged" ></asp:GridView>
