        public class Model {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public partial class Checkboxes : System.Web.UI.Page {
            protected void Page_Load(object sender, EventArgs e) {
                if(!IsPostBack ) {
                    repeater1.DataSource = new List<Model> { 
                                   new Model { Id = 1, Name = "a" }, 
                                   new Model { Id = 2, Name = "b" }, 
                                   new Model { Id = 3, Name = "c" } };
                    repeater1.DataBind();
                }
            }
            protected void repeater1_OnItemDataBound(Object sender, RepeaterItemEventArgs e) {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                    var item = e.Item.DataItem as Model;
                    if (item != null) {
                        var chk = e.Item.FindControl("chk") as CheckBox;
                        if (chk != null) {
                            chk.Text = item.Name;
                            chk.InputAttributes.Add("value", item.Id.ToString());
                        }
                    }
                }
            }
            protected void Check_Changed(Object sender, EventArgs e) {
                var id = ((CheckBox) sender).InputAttributes["value"];
                //you now have access to the item id and can manipulate at will.
            }
        }
