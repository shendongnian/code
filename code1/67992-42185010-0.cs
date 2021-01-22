            /// <summary>
            /// Recreates the items
            /// </summary>
            public static void RefreshItems(this ComboBox cb)
            {
                var selectedIndex = cb.SelectedIndex;
                cb.SelectedIndex = -1;            
                MethodInfo dynMethod = cb.GetType().GetMethod("RefreshItems", BindingFlags.NonPublic | BindingFlags.Instance);
                dynMethod.Invoke(cb, null);
                cb.SelectedIndex = selectedIndex;
    
            }
