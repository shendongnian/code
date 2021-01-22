            var uC = new UserControl();
            var iC = new ItemsControl();
            uC.Content = iC;
            RegionManager.SetRegionName(iC, "ItemsControlRegionAdapterTestRegion");
            regionManager.AddToRegion(RegionNames.MainRegion, uC);
