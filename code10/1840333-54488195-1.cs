        public override void OnResume()
        {
            base.OnResume();
            //...
            _refreshTimer = new System.Threading.Timer(RefreshView, null, 0, 1000);
        }
        public override void OnPause()
        {
            base.OnPause();
            //...
            _refreshTimer.Dispose();
        }
