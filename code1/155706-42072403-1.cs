      List<ErrorList> Errors = new List<ErrorList>(); 
         
            //test errors.
            var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
            foreach (var x in modelStateErrors)
            {
                var errorInfo = new ErrorList()
                {
                    ErrorMessage = x.ErrorMessage
                };
                Errors.Add(errorInfo);
               
            }
