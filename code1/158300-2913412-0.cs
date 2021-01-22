        private void LoadTree()
        {
            foreach (DeviceGroup dg in ttvm.DeviceGroups)
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = dg;
                treeView1.Items.Add(tvi);
                AddTreeItems(tvi, dg);
            }
        }
        private void AddTreeItems(TreeViewItem node, DeviceGroup deviceGroup)
        {
            foreach (DeviceGroup dg in deviceGroup.DeviceGroups)
            {
                TreeViewItem groupTVI = new TreeViewItem();
                groupTVI.Header = dg;
                node.Items.Add(groupTVI);
                AddTreeItems(groupTVI, dg);
            }
 
            foreach (Device device in deviceGroup.Devices)
            {
                TreeViewItem deviceTVI = new TreeViewItem();
                deviceTVI.Header = device;
                node.Items.Add(deviceTVI);
            }
        }
