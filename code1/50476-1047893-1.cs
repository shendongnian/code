        #region ISupportInitialize Members
        public void BeginInit()
        {
            // do nothing
        }
        public void EndInit()
        {
            if (DesignMode)
                return;
            foreach (Component item in _disableOnlineHelp)
            {
                if (item == null)
                    continue;
                if (GetDisableOnlineHelp(item)) // developer has decide to set property to TRUE
                    continue;
                Control control = item as Control;
                if (control != null)
                    continue;
                control.HelpRequested += new HelpEventHandler(HelpProvider_HelpRequested);
                _toolTip.SetToolTip(control, GetHelpText(control));
            }
        }
        #endregion
        #region DisableOnlineHelp Provider Property
        public virtual bool GetDisableOnlineHelp(Component component)
        {
            object flag = _disableOnlineHelp[component];
            if (flag == null)
                return false;
            return (bool)flag;
        }
        public virtual void SetDisableOnlineHelp(Component component, bool value)
        {
            _disableOnlineHelp[component] = value;
        }
        
        #endregion
