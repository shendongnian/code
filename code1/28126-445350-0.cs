    public void DragWindow(object sender, MouseButtonEventArgs args)
    {
         DragMove();
         UpdatePosition();
    
         childForm.DragMove();
         childForm.UpdatePosition();
    }
