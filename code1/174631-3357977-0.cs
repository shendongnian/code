        protected override void OnResolveControlID(ResolveControlEventArgs e)
        {
            // Get a reference to the outermost TabContainer that contains the TabPanel being extended.
            TabContainer tabContainer = (TabContainer)base.FindControl(OuterTabPanelID);
            if (tabContainer != null)
            {
                // Check to see if any of the tabs are the control we are looking form.
                foreach (TabPanel tab in tabContainer.Tabs)
                {
                    if (tab.ID == e.ControlID)
                    {
                        e.Control = tab;
                        return;
                    }
                }
                // If none of the tabs are what we are looking for, search the contents of each tab.
                foreach (TabPanel tab in tabContainer.Tabs)
                {
                    Control ctrl = tab.FindControl(e.ControlID);
                    if (ctrl != null)
                        return;
                }
            }
        }
