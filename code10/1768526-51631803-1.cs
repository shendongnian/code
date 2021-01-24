        public static void MyMethod<T>(IEnumerable<T> query)
        {
            var t = typeof(T);
            var Headings = t.GetProperties();
            for (int i = iteratorStart; i < Headings.Count(); i++)
            {
                if (false == IsValue(Headings[i].PropertyType.FullName))
                {
                   Type type = Type.GetType(Headings[i].PropertyType.FullName);
                   var mi = typeof(ExcelExtension);
                   var met  = mi.GetMethod("ListToExcel");
                   var genMet = met.MakeGenericMethod(type);
                   //Assuming you want to get property value here. IF not You can use like Headings[i].GetName
                   var nested = query.Select(p =>Convert.ChangeType( Headings[i].GetValue(p),Headings[i].GetType()));
                   object[] parametersArray = new object[] { pck, nested, i };
                   genMet.Invoke(null, parametersArray);
                }
            }
    
    }
