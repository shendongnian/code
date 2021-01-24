    private bool IsDrag { get; set; }              
    
            protected override void OnAttached()
            {            
                this.AssociatedObject.Drop += AssociatedObject_Drop;            
                this.AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObject_PreviewMouseLeftButtonDown;
                this.AssociatedObject.PreviewMouseMove += AssociatedObject_PreviewMouseMove;
    
            }
    
            private void AssociatedObject_PreviewMouseMove(object sender, MouseEventArgs e)
            {                                  
                if (e.LeftButton == MouseButtonState.Pressed)
                {               
                    if(IsDrag)
                    {
                        StartDrag(sender);
                    }
                }
            }
    
            private void AssociatedObject_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                IsDrag = false;    
                
                if(sender is ListBox)
                {
                    Point initialPoint = e.GetPosition((UIElement)sender);
                    var histPoint = VisualTreeHelper.HitTest(sender as ListBox, initialPoint);
    
                    if (histPoint.VisualHit != null)
                    {
                        if (histPoint.VisualHit is TextBlock || histPoint.VisualHit is Border)
                        {
                            IsDrag = true;
                        }
                    }
                }            
            }                   
    
            private void StartDrag(object sender)
            {            
                if (sender is ListBox)
                {
                    var listBox = (sender as ListBox);
                    if (listBox != null)
                    {
                        var selectedMember = listBox.SelectedItem;
                        if (selectedMember != null)
                        {
                            DragDrop.DoDragDrop(listBox, selectedMember, DragDropEffects.Copy);
                        }
                    }
                }           
            }
