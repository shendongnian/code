            string propName = col.DataPropertyName;
            // could also be a dictionary/hashset etc
            // could be typed if you know the type
            List<object> values = new List<object>();
            foreach(DataGridViewRow row in dgv.Rows)
            {
                object obj = row.DataBoundItem;
                // could be typed (via cast) if you know the type
                object val = TypeDescriptor.GetProperties(obj)[propName].GetValue(obj);
                if (!values.Contains(val))
                {
                    values.Add(val);
                }
            }
