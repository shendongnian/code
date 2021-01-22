    public partial class GridEditing_EditForm : BasePage {
     protected void Page_Load(object sender, EventArgs e) {
 
     }
     Hashtable copiedValues = null;
     string[] copiedFields = new string[] { "FirstName", "Title", "Notes", "LastName", "BirthDate", "HireDate" };
     protected void grid_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e) {
         if(e.ButtonID != "Copy") return;
         copiedValues = new Hashtable();
         foreach(string fieldName in copiedFields) {
             copiedValues[fieldName] = grid.GetRowValues(e.VisibleIndex, fieldName);
         }
         grid.AddNewRow();
 
     }
     protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e) {
         if(copiedValues == null) return;
         foreach(string fieldName in copiedFields) {
             e.NewValues[fieldName] = copiedValues[fieldName];
         }
     }
    }
