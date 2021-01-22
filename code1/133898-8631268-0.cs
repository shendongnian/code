    public class RefreshDataGridRowDetailAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke(object parameter)
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
    
            //Refresh height because DataGrid row height only grows but won't shrink back
            if (rowDetailPresenter != null)
            {
                rowDetailPresenter.ContentHeight = 0;
                rowDetailPresenter.UpdateLayout();
            }
        }
    }
