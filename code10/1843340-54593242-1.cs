     public ResponseModel Process(ChangePositioningPlan command)
        {
            try
            {
                // your current method code
                ResponseModel response = new ResponseModel();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception)
            {
                ResponseModel response = new ResponseModel();
                response.IsSuccess = false;
                response.ErrorMessage = "Your error message to show";
                return response;
            }
        }
   
    [HttpPatch]
    [CatchException]
    public IHttpActionResult ChangePositioningPlan(ChangePositioningPlan changeCommand)
    {
        return Ok(changePositioingPlan.Process(changeCommand));
    }
      
