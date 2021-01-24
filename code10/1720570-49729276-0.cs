    var sort = emsort.Text;
    PropertyInfo property = null;
    var sortedData = el.Select(i => new { i.ID, i.FullName })
         .OrderBy(x => 
         {
              if(property == null)
                  property = x.GetType().GetProperty(sort);
              return property.GetValue(x);
         }).ToList();
