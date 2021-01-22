    interface IConfigurableVisibilityControl
    {
        //check box that controls whether current control is visible
        CheckBox VisibleCheckBox {get;}
    }
    class MySuperDuperUserControl : UserControl, IConfigurableVisibilityControl
    {
        private readonly CheckBox _visibleCheckBox = new CheckBox();
        public CheckBox VisibleCheckBox 
        {
            get { return _visibleCheckBox; }
        }
        //other important stuff
    }
    //somewhere else
    void BuildSomeUi(Form f, ICollection<UserControl> controls)
    {
        //Add "configuration" controls to special panel somewhere on the form
        Panel configurationPanel = new Panel();
        Panel mainPanel = new Panel();
        //do some other lay out stuff
        f.Add(configurationPanel);
        f.Add(mainPanel);
        foreach(UserControl c in controls) 
        {
            //check whether control is configurable
            IConfigurableOptionalControl configurableControl = c as IConfigurableVisibilityControl;
            if(null != configurableControl) 
            {
                CheckBox visibleConfigCB = configurableControl.VisibleCheckBox;
                //do some other lay out stuff
                configurationPanel.Add(visibleConfigCB);
            }
            //do some other lay out stuff
            mainPanel.Add(c);
        }
    }
