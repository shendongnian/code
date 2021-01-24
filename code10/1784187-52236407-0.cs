    [HttpGet]
    public IHttpActionResult getAllAccounts(string BRN, string CompanyName) {
        try {
            ResponseData response = new ResponseData();
            List<AccountDTO> accountlist = null;
            IAccountInterface usecase = new AccountDAO();
            if (BRN != null && CompanyName != null) {
                accountlist = usecase.getAccountbyBRNCompanyName().Where(p => p.BRN.ToLower().Equals(BRN.ToLower()) && p.CompanyName.ToLower().Contains(CompanyName.ToLower())).ToList();
                response.ReturnMessage = "Data filter by BRN and CompanyName.";
            } else {
                response.ReturnMessage = "Data filter cannot be null.";
            }
            response.AccountList = accountlist;
            return Ok(response);
        }
        catch (Exception e) {
            Console.WriteLine("Error: " + e.Message + ", Stack: " + e.StackTrace);
            var response = new {
                code = "sample code",
                message = e.Message,
                innererror = new {
                    message = e.Message,
                    type = "ExceptionType + ...",
                    stacktrace = e.StackTrace
                }
            }
            var responseMessage = Request.CreateResponse(HttpStatusCode.ServerError, response);
            return ResponseMessage(responseMessage);
        }
    }
