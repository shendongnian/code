     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
          <asp:FileUpload ID="fileUpload" runat="server"></asp:FileUpload>
          <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" />
          </ContentTemplate>
          <Triggers>
              <asp:PostBackTrigger ControlID="btnUpload"  />
          </Triggers>
     </asp:UpdatePanel>
    
     protected void btnUpload_Click(object sender, EventArgs e)
         {
            if (fileUpload1.HasFile)
            {                
                fileUpload1.SaveAs("~/UploadedContent/" + fileupload1.FileName);
            }
         }
