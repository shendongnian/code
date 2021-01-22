        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            WorkingScreen = Screen.AllScreens.ToList().FirstOrDefault(s => s.WorkingArea == Screen.GetWorkingArea(this));
        }
        Screen _WorkingScreen = null;
        Screen WorkingScreen
        {
            get { return _WorkingScreen; }
            set
            {
                if (WorkingScreen != value)
                {
                    _WorkingScreen = value;
                    // Screen changed!
                }
            }
        }
