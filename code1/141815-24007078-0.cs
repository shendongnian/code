            Value = "";
            var v = t.GetType().GetProperties();
            if (t.GetType().GetProperties().Count(p => p.Name == PropertName.Split('.')[0]) == 0)
                //throw new ArgumentNullException(string.Format("Property {0}, is not exists in object {1}", PropertName, t.ToString()));
                return null;
            if (PropertName.Split('.').Length == 1)
            {
                var Value1 = t.GetType().GetProperty(PropertName).GetValue(t, null);
                Value = Value1;//.ToString();
                return t.GetType().GetProperty(PropertName);
            }
            else
            {
                //return GetProperty(t.GetType().GetProperty(PropertName.Split('.')[0]).GetValue(t, null), PropertName.Split('.')[1], out Value);
                return GetProperty(t.GetType().GetProperty(PropertName.Split('.')[0]).GetValue(t, null), PropertName.Substring(PropertName.IndexOf('.') + 1, PropertName.Length - PropertName.IndexOf('.') - 1), out Value);
            }
        }
