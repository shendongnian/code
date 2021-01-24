`
<div class="scroll" style="overflow: visible">
    <asp:PlaceHolder runat="server" ID="tblMainReportPlaceHolder">
        <asp:Table ID="tblMainReport" runat="server" CellPadding="2"
            CellSpacing="2" HorizontalAlign="Center" GridLines="Both" Width="100%">
        </asp:Table>
    </asp:PlaceHolder>
</div>
`
Then in your GetDetailReconciliation method, add your saved session instance of tblMainReport to your placeholder:
`
if (Session["tblMyMainReport"] != null)
{
    tblMainReportPlaceHolder.Controls.Clear();
    tblMainReportPlaceHolder.Controls.Add((Control)Session["tblMyMainReport"]);
}
`
This should restore your saved table instance in a way that will allow Web Forms to render it.
Bellow I'm providing a working generic example of this approach:
**Markup**
`
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebSandbox.WebForm1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Generate Table" runat="server" ID="generateTableButton" OnClick="generateTableButton_Click" />
            <asp:Button Text="Restore Table" runat="server" ID="restoreTableButton" OnClick="restoreTableButton_Click" />
            <asp:PlaceHolder runat="server" ID="tblMainReportPlaceHolder">
                <asp:Table ID="tblMainReport" runat="server" CellPadding="2"
                    CellSpacing="2" HorizontalAlign="Center" GridLines="Both" Width="100%">
                </asp:Table>
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
`
**Code behind**
`
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebSandbox
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void generateTableButton_Click(object sender, EventArgs e)
        {
            var cell1 = new TableCell
            {
                Text = "Cell 1"
            };
            var cell2 = new TableCell
            {
                Text = "Cell 2"
            };
            var row = new TableRow();
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            tblMainReport.Rows.Add(row);
            Session["tblMyMainReport"] = tblMainReport;
        }
        protected void restoreTableButton_Click(object sender, EventArgs e)
        {
            tblMainReportPlaceHolder.Controls.Clear();
            tblMainReportPlaceHolder.Controls.Add((Control)Session["tblMyMainReport"]);
        }
    }
}
`
Alternatively, you could just call the logic used to built your table, every time you need it to render.
