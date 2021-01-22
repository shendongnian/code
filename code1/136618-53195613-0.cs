    private void personBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
    {
        if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate &&
            e.BindingCompleteState == BindingCompleteState.Success) {
            object model = e.Binding.BindingManagerBase.Current;
            if (model != null) {
                Type modelType = model.GetType();
                string propertyName = e.Binding.BindingMemberInfo.BindingField;
                PropertyInfo modelProp = modelType.GetProperty(propertyName);
                object value = modelProp.GetValue(model);
                System.Diagnostics.Debug.WriteLine($"{propertyName} = {value}");
            }
        }
    }
