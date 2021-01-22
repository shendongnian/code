        public bool IsIdle
        {
            get
            {
                TimeSpan activityThreshold = TimeSpan.FromMinutes(1);
                TimeSpan machineIdle = Support.User32Interop.GetLastInput();
                TimeSpan? appIdle = this._lostFocusTime == null ? null : (TimeSpan?)DateTime.Now.Subtract(_lostFocusTime.Value);
                bool isMachineIdle = machineIdle > activityThreshold ;
                bool isAppIdle = appIdle != null && appIdle > activityThreshold ;
                return isMachineIdle || isAppIdle;
            }
        }
