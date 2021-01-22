    <%@ Control Language="C#" AutoEventWireup="true" %>
    <%@ Import Namespace="System.Data.SqlTypes"%>
    <%@ Register Src="~/SomeControl.ascx" TagPrefix="test" TagName="SomeControl" %>
    
    <script type="text/C#" runat="server">
    	public SqlDateTime Time
    	{
    		get { return SomeControl1.Time; }
    		set { SomeControl1.Time = (DateTime)value; }
    	}
    </script>
    
    <test:SomeControl ID="SomeControl1" runat="server" />
