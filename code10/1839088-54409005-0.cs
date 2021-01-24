    [HttpPut]
    public async Task<JsonResult> UpdateRegistrationRequirementAsync(RegistrationRequirement regRequirementModel )
    {
        try
        {
            var response = await ServiceClient.L09PutRegistrationRequirementAsync(CurrentUser.PersonId, regRequirementModel);
            return Json(response);
        }
        catch( Exception ex)
        {
            Logger.Debug(ex, "Error updating Registration Requirement for user failed.");
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Error updating Registration Requirement.");
        }       
