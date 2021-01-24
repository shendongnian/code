     private string CreateSqlFilter(string fieldName, Control userInputControl, SqlCommand command, bool exactMatch,
         bool isRange = false, Control userInputControl2 = null)
     {
         if (isRange)
         {
             string searchValue1 = null;
             if (userInputControl is TextBox) searchValue1 = ((TextBox)userInputControl).Text;
             if (userInputControl is ComboBox) searchValue1 = ((ComboBox)userInputControl).Text;
             string searchValue2 = null;
             if (userInputControl2 is TextBox) searchValue2 = ((TextBox)userInputControl2).Text;
             if (userInputControl2 is ComboBox) searchValue2 = ((ComboBox)userInputControl2).Text;
             if (String.IsNullOrWhiteSpace(searchValue1) && String.IsNullOrWhiteSpace(searchValue2)) return null;
             if (!String.IsNullOrWhiteSpace(searchValue1) && !String.IsNullOrWhiteSpace(searchValue2))
             {
                 command.Parameters.Add(new SqlParameter("@" + fieldName + "From", searchValue1));
                 command.Parameters.Add(new SqlParameter("@" + fieldName + "To", searchValue2));
                 return $"{fieldName} BETWEEN @{fieldName}From AND @{fieldName}To";
             }
             if (!String.IsNullOrWhiteSpace(searchValue1))
             {
                 command.Parameters.Add(new SqlParameter("@" + fieldName + "From", searchValue1));
                 return $"{fieldName} >= @{fieldName}From";
             }
             command.Parameters.Add(new SqlParameter("@" + fieldName + "To", searchValue2));
             return $"{fieldName} <= @{fieldName}To";
         }
         string searchValue = null;
         if (userInputControl is TextBox) searchValue = ((TextBox)userInputControl).Text;
         if (userInputControl is ComboBox) searchValue = ((ComboBox)userInputControl).Text;
         if (String.IsNullOrWhiteSpace(searchValue)) return null;
         if (exactMatch)
         {
             command.Parameters.Add(new SqlParameter("@" + fieldName, searchValue));
             return fieldName + " = @" + fieldName;
         }
         else
         {
             command.Parameters.Add(new SqlParameter("@" + fieldName, "%" + searchValue + "%"));
             return fieldName + " LIKE @" + fieldName;
         }
     }
