     public void getObjectNamesAndValue(object obj)
        {
            Type type = obj.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] prop = type.GetProperties(flags);
            foreach (var pro in prop)
            {
                System.Windows.Forms.MessageBox.Show("Name :" + pro.Name + " Value : "+  pro.GetValue(obj, null).ToString());
            }
        }
        
