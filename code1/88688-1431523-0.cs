            private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(SqlServerTable)))
            {
              FieldInfo info;
    
              object obj;
    
              info = e.Data.GetType().GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance);
    
              obj = info.GetValue(e.Data);
    
              info = obj.GetType().GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance);
    
             System.Windows.DataObject dataObj = info.GetValue(obj) as System.Windows.DataObject;
    
             SqlServerTable table = dataObj.GetData("Project.SqlServerTable") as SqlServerTable ;
            }
        }
