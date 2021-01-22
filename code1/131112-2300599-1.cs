        private void ForEachControlRecursive(object root, Action<Control> action, bool IsRead)
        {
            Control control = root as Control;
            //if (control != null)
            //    action(control);
            // Process control
            ProcessControl(control, IsRead);
            // Check child controls
            if (root is DependencyObject && CanWeCheckChildControls(control))
                foreach (object child in LogicalTreeHelper.GetChildren((DependencyObject)root))
                    ForEachControlRecursive(child, action, IsRead);
        }
