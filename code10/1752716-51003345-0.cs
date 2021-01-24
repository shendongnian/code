    //This is your .aspx code. The AllowMultiple on FileUpload only works in .NET Framework 4.5+
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Button1" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
    //This is your code behind
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFiles)
        {
            foreach (var file in FileUpload1.PostedFiles)
            {
                string value = Guid.NewGuid().ToString();
                string extension = new FileInfo(file.FileName).Extension;
                string path = Server.MapPath("~/pimg/" + value + extension);
                string virtualPath = "/pimg/" + value + extension;
                System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                img.Save(path);
                if (Request.Cookies["aa"] == null)
                {
                    Response.Cookies["aa"].Value = virtualPath;
                }
                else
                {
                    Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + virtualPath;
                }
            }
        }
        if (Request.Cookies["aa"] != null)
        {
            string[] picArray = Convert.ToString(Request.Cookies["aa"].Value).Split('|');
            foreach (var item in picArray)
            {
                Image img = new Image();
                img.ImageUrl = item.ToString();
                img.Height = 150;
                img.Width = 100;
                UpdatePanel1.ContentTemplateContainer.Controls.Add(img);
            }
        }
    }
