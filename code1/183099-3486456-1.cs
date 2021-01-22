    private void ScanThread()
        {
            while (true) {
                listView1.Invoke(new APScanCallback(APScan));
                Thread.Sleep(10000);
            }
        }
        public void APScan() 
        {
                listView1.Items.Clear();
                foreach (AccessPoint ap in wzcInterface.NearbyAccessPoints)
                {
                    ListViewItem item = new ListViewItem(ap.Name);
                    item.SubItems.Add(ap.PhysicalAddress.ToString());
                    item.SubItems.Add(ap.SignalStrength.Decibels.ToString());
                    item.SubItems.Add(ap.AuthenticationMode.ToString());
                    listView1.Items.Add(item);
                }
                listView1.Refresh();
         }
                
