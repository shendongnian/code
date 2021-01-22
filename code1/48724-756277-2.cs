       public static void CheckAllBoxes(DependencyObject obj, bool isChecked)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                // If a checkbox, change IsChecked and continue.
                if (obj is CheckBox)
                {
                    ((CheckBox) obj).IsChecked = isChecked;
                    continue;
                }
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                CheckAllBoxes(child, isChecked);
            }
        }
