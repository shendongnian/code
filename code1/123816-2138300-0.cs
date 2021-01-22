    class BooleanDataField : DataField {
    
        protected override void OnApplyTemplate() {
    
            if (this.Content == null) {
                var check = new CheckBox();
                check.SetBinding(CheckBox.IsCheckedProperty, 
                    new Binding(this.PropertyPath));
                this.Content = check;
            }
    
            base.OnApplyTemplate();
        }
    
    }
