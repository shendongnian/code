    var targetRange = Application.get_Range("A1:A5");
    for (int i = 1; i <= targetRange.Count; i++)
    {
      // Range Item returns... Range! Gotta love this API...
      var range = (Range)targetRange.Item[i];
      object value = range.Value2;
    
      // Test-and-cast
      if (value is string) {
         var strValue = (string)value;
         // Do string things
      }
      elseif (value is double) {
         var dValue = (double)value;
         // Do double things
      }
      (...)
    
      // For C#7 or above, use 'pattern matching switch' instead of above test-and-cast
      switch(value) {
         case string strValue:
            // Do string things
            break;
         case double dValue:
            // Do double things
            break;
         (...)
      }
    }
