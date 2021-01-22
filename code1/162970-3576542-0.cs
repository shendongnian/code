        public event EventHandler<DDSelectionChangedEventArgs> DDSelectionChanged;
        public virtual void OnDDSelectionChanged(DDSelectionChangedEventArgs e)
        {
            if (DDSelectionChanged != null)
            {
                DDSelectionChanged(this, e);
            }
        }
