    public class DataGridDetailResizeBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SizeChanged += new SizeChangedEventHandler(Element_SizeChanged);
        }
    
        protected override void OnDetaching()
        {
            this.AssociatedObject.SizeChanged -= new SizeChangedEventHandler(Element_SizeChanged);
            base.OnDetaching();
        }
    
        private void Element_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Find DataGridDetailsPresenter
            DataGridDetailsPresenter rowDetailPresenter = null;
            var element = this.AssociatedObject;
            while (element != null)
            {
                rowDetailPresenter = element as DataGridDetailsPresenter;
                if (rowDetailPresenter != null)
                {
                    break;
                }
    
                element = (FrameworkElement)VisualTreeHelper.GetParent(element);
            } 
    
            if (rowDetailPresenter != null)
            {
                var row = UIHelper.GetParentOf<DataGridRow>(this.AssociatedObject);
                if (row != null && row.DetailsVisibility == Visibility.Visible)
                {
                    //Set height
                    rowDetailPresenter.ContentHeight = this.AssociatedObject.ActualHeight;
                }
            }
        }
    }
