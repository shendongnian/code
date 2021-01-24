            void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            // Check the time. If less than 100 ms has elapsed, don't do anything
            if (DateTime.Now - lastItemAppearingTime <= TimeSpan.FromMilliseconds(100))
                return; 
            MyItemType item = e.Item as MyItemType;
            currentItemIndex = Items.IndexOf(item);
            if (currentItemIndex > lastItemIndex)
            {
                Console.WriteLine("Scrolling down");
                stackLayout.IsVisible = true;
            }
            // Don't do anything if item is the same
            else if (currentItemIndex == lastItemIndex)
                return;
            else
            {
                Console.WriteLine("Scrolling up");
                stackLayout.IsVisible = false;
            }
            lastItemIndex = currentItemIndex;
            lastItemAppearingTime = DateTime.Now;
        }
