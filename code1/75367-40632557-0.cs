    public class MyObjectDataSource : ObjectDataSource
    {
        public MyObjectDataSource()
        {
            this.ObjectCreated += this.MyObjectDataSource_ObjectCreated;
        }
        private void MyObjectDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            var objectDataSourceView = sender as ObjectDataSourceView;
            if (objectDataSourceView != null && objectDataSourceView.TypeName.EndsWith("TableAdapter"))
            {
                var adapter = e.ObjectInstance;
                PropertyInfo adapterProp = adapter.GetType()
                    .GetProperty(
                        "CommandCollection",
                        BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance);
                if (adapterProp == null)
                {
                    return;
                }
                SqlCommand[] commandCollection = adapterProp.GetValue(adapter, null) as SqlCommand[];
                if (commandCollection == null)
                {
                    return;
                }
                foreach (System.Data.SqlClient.SqlCommand cmd in commandCollection)
                {
                    cmd.CommandTimeout = 120;
                }
            }
        }
    }
