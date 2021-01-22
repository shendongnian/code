        protected void Page_Load(object sender, EventArgs e)
        {
            PlaceHolder.Controls.Add(new CheckBox {ID = "findme"});
        }
        protected void Submit_OnClick(object sender, EventArgs e)
        {
            var checkBox = PlaceHolder.FindControlRecursive("findme") as CheckBox;
        }
