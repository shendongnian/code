    //iterate through the child controls of "grid"
    int count = VisualTreeHelper.GetChildrenCount(grid);
                for (int i = 0; i < count; i++)
                {
                  Visual childVisual = (Visual)VisualTreeHelper.GetChild(grid, i);
                    if (childVisual is TextBox)
                    {
                        //write some logic code
                    }
                   else
                   {
                   }
                }
