        protected override void OnApplyTemplate()
        {
            try
            {
                // find something in TestingControl.Resources
                var x = Resources["myHeight"];
            }
            catch (Exception e)
            {
                
            }
            try
            {
                // find something in App.Resources
                var x = App.Current.Resources["myHeight"];
            }
            catch (Exception e)
            {
                
            }
            base.OnApplyTemplate();
        }
