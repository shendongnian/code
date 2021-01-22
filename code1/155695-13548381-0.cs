     public class ErrorDetail {
    
            public string fieldName = "";
            public string[] messageList = null;
     }
*********************
            if (!modelState.IsValid)
            {
                var errorListAux = (from m in modelState 
                         where m.Value.Errors.Count() > 0 
                         select
                            new ErrorDetail
                            { 
                                    fieldName = m.Key, 
                                    errorList = (from msg in m.Value.Errors 
                                                 select msg.ErrorMessage).ToArray() 
                            })
                         .AsEnumerable()
                         .ToDictionary(v => v.fieldName, v => v);
                return errorListAux;
            }
