    <script runat="server" type="text/C#">
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MasterModel = SiteMasterViewData.Get(this.Context);
        }
        protected SiteMasterViewData MasterModel;
    </script>
