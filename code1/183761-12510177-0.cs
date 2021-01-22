     public void ShowForm(CForm pForm)
        {
            pForm.MdiParent = this;
            Size lS = pForm.Size;
            dockPanel.DefaultFloatWindowSize = lS;
            pForm.Show(dockPanel);
            pForm.VisibleState = DockState.Float;
        }
