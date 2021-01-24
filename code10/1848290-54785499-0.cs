<asp:GridView ID="GridView1" runat="server" AllowSorting="true" 
OnSorting="GridView1_Sorting">
    Your gridview here...
</asp:GridView>
Now, you should have a partial class right below your .aspx.cs, which is usually under the extension .aspx.designer.cs. This class will be used to declare your components, as it follows:
namespace YourApplication {
    //This should have the same name as you .aspx.cs
    public partial class _Default {
        protected global::System.Web.UI.WebControls.GridView GridView1;
    }
}
Then you should be able to access it.
