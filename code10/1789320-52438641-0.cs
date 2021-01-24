      // You don't wanty formatting
      var dateFrom = new DateTime(dateProperty.Value.Year - 1, 4, 1);    
      // object.nullablebool == true - if object.nullablebool has value and the value is true
      if (object.nullablebool == true && (string == "V" || string == "N")) {
        // if someDate.Value is null the result will be false 
        // All we have to do is to propagate the null: ?. in someDate?.Date
        if (someDate?.Date > dateFrom.Date && object.SomeOtherDate.HasValue) {
          // Code
        }
        else {  
          // Code
        }
      }
