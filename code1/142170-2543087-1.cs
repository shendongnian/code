    FrameworkElement parent = (FrameworkElement)this.Parent;
            while (true)
            {
                if (parent == null)
                    break;
                if (parent is Page)
                {
                    //Do your stuff here. MessageBox is for demo only
                    MessageBox.Show(((Window)parent).Title);
                    break;
                }
                parent = (FrameworkElement)parent.Parent;
            }
