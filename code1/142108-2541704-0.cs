     //Start our advertisiment thread
        rotator = new Thread(initRotate);
        rotator.Priority = ThreadPriority.Lowest;
        rotator.Start();
        #region Ad Rotation
        private delegate void ad();
        private void initRotate()
        {
            ad ad = new ad(adHelper);
            while (true)
            {
                this.Invoke(ad);
                Thread.Sleep(30000);
            }
        }
        private void adHelper()
        {
            List<string> tmp = Lobby.AdRotator.RotateAd();
            picBanner.ImageLocation = @tmp[0].ToString();
            picBanner.Tag = tmp[1].ToString();            
        }
        #endregion
