        bool m_fetching;
        void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            if (m_fetching) return;
            if (args.Position.LatitudeValid && args.Position.LongitudeValid)
            {
                ThreadPool.QueueUserWorkItem(UpdateProc, args);
            }
        }
        private void UpdateProc(object state)
        {
            m_fetching = true;
            LocationChangedEventArgs args = (LocationChangedEventArgs)state;
            try
            {
                // do this async
                var image = image_request2(args.Position.Latitude, args.Position.Longitude);
                // now that we have the image, do a synchronous call in the UI
                pictureBox1.Invoke((UpdateMap)delegate()
                {
                    center.Latitude = args.Position.Latitude;
                    center.Longitude = args.Position.Longitude;
                    LatLongToPixel(center);
                    image;
                });
            }
            finally
            {
                m_fetching = false;
            }
        }
