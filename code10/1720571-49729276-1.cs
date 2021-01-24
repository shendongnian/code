    var sort = emsort.Text;
    PropertyInfo property = null;
    var sortedData = el.Select(i => new { i.ID, i.FullName })
         .OrderBy(x => 
         {
              property = property ?? x.GetType().GetProperty(sort);
              return property.GetValue(x);
         }).ToList();
