    public partial class FolderButton : System.Web.UI.UserControl
    {
        public int DatabaseId { get; set; }
        public string Name { get; set;}  // you can even set your linkbutton text here. 
        public event EventHandler Click;
    }
