        private void ChangeTimeout(Component component, int timeout)
        {
            if (!component.GetType().Name.Contains("TableAdapter"))
            {
                return;
            }
            PropertyInfo adapterProp = component.GetType().GetProperty("Adapter", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance);
            if (adapterProp == null)
            {
                return;
            }
            SqlDataAdapter adapter = adapterProp.GetValue(component, null) as SqlDataAdapter;
            if (adapter == null)
            {
                return;
            }
            adapter.SelectCommand.CommandTimeout = timeout;
        }
