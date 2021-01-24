    public static class UpdateContentItems
    {
        public static void Set(ListBox listBox)
        {
            var items = listBox.ItemsSource;
            foreach (var item in items)
            {
                var contentItem = item as ContentItem;
                if (contentItem.Name == "Banked")
                {
                    contentItem.Content = new BankedWindow();
                }
            }
        }
    }
