        private void dgScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            int i = 0;
            DataGrid dg = (DataGrid)sender;
            foreach (ObservableFlatObservations o in dg.Items)
            {
                UIElement v = (UIElement)dg.ItemContainerGenerator.ContainerFromItem(o);
                GeneralTransform childTransform = v.TransformToAncestor((ScrollViewer)sender);
                Rect rectangle = childTransform.TransformBounds(new Rect(new Point(0, 0), v.RenderSize));
                Rect result = Rect.Intersect(new Rect(new Point(0, 0), ((ScrollViewer)sender).RenderSize), rectangle);
                if (result != Rect.Empty)
                {
                    //This one is visible so do some stuff
                    return;// i is the index of this item
                }
                i++;
            }
        }
