    public partial class DrawerControl : UserControl
    {
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PlaceHolder BodyContent { get; set; }
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PlaceHolder GripContent { get; set; }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            phBodyContent.Controls.Add(BodyContent);
            phGripContent.Controls.Add(GripContent);
        }
    }
