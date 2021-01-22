    <%@ Control Language="C#" AutoEventWireup="true" %>
    <script type="text/C#" runat="server">
    	public DateTime Time
    	{
    		get { return string.IsNullOrEmpty(output.Text) ? DateTime.MinValue : DateTime.Parse(output.Text); }
    		set { output.Text = value.ToString(); }
    	}
    </script>
    
    <asp:Literal runat="server" id="output" />
