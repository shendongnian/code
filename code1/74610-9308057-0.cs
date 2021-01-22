    Dispatcher.BeginInvoke(delegate { TextBlockList = GetFirstChildOfType<TextBlock>(listBox1); });
      List<T> GetFirstChildOfType<T>(DependencyObject visual) where T : DependencyObject
        {
            DependencyObject ControlCandidate;
            List<T> TempElements;
            List<T> TargetElementList = new List<T>();
            
 
            var itemCount = VisualTreeHelper.GetChildrenCount(visual);
            if (itemCount > 0)
            {
                for (int i = 0; i < itemCount; i++)
                {
                    ControlCandidate = VisualTreeHelper.GetChild(visual, i);
                    if (ControlCandidate is T)
                        TargetElementList.Add((T)ControlCandidate);
                }
 
                for (int i = 0; i < itemCount; i++)
                {
                    TempElements = GetFirstChildOfType<T>(VisualTreeHelper.GetChild(visual, i));
                    if (TempElements.Count > 0)
                        TargetElementList.AddRange(TempElements);
                }
            }
 
            return TargetElementList;
        }
