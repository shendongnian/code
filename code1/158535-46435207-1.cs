        private void Grid_Drop(object sender, DragEventArgs e)
        {
            int dropIndex = -1; // default position directong to add() call
            // checking drop destination position
            Point pt = e.GetPosition((UIElement)sender);
            HitTestResult result = VisualTreeHelper.HitTest(this, pt);
            if (result != null && result.VisualHit != null)
            {
                // checking the object behin the drop position (Item type depend)
                var theOne = result.VisualHit.FindParent<Microsoft.TeamFoundation.Controls.WPF.DraggableListBoxItem>();
                // identifiing the position according bound view model (context of item)
                if (theOne != null)
                {
                    //identifing the position of drop within the item
                    var itemCenterPosY = theOne.ActualHeight / 2;
                    var dropPosInItemPos = e.GetPosition(theOne); 
                    // geting the index
                    var itemIndex = tasksListBox.Items.IndexOf(theOne.Content);                    
                    // decission if insert before or below
                    if (dropPosInItemPos.Y > itemCenterPosY)
                    {  // when drag is gropped in second half the item is inserted bellow
                        itemIndex = itemIndex + 1; 
                    }
                    dropIndex = itemIndex;
                }
            }
            .... here create the item .....
            
            if (dropIndex < 0)
                 ViewModel.Items.Add(item);
            else
                 ViewModel.Items.Insert(dropIndex, item);
            e.Handled = true;
        }
