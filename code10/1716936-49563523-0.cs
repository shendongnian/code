        protected override void OnPreInit(EventArgs e)
        {
            string controlToLoad = String.Empty;
            //logic to determine which control to load
            UserControl userControl = (UserControl)LoadControl(controlToLoad);
            renderhere.Controls.Add(userControl);
            base.OnPreInit(e);
        }
