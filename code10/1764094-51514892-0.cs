        if (child is GroupBox)
        {
           if ((child as GroupBox).Content is StackPanel)
           {
               StackPanel d = (StackPanel)((GroupBox)child).Content; 
           }
         }
