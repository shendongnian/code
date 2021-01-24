    FunctionName("PatchInstitute")]
        public async Task<IActionResult> PatchInstitute(
            [HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = ApiConstants.BaseRoute + "/institute/{instituteId}")] HttpRequest req,
            ILogger log, [Inject]IInstituteValidator instituteValidator, int instituteId, [Inject] IInstituteProvider instituteProvider)
        {
            try
            {
               //get existing record with Id here
                var instituteDto = instituteProvider.GetInstitueProfileById(instituteId);
               
                using (StreamReader streamReader = new StreamReader(req.Body))
                {
                    var requestBody = await streamReader.ReadToEndAsync();
                    //Deserialize bosy to strongly typed JsonPatchDocument
                    JsonPatchDocument<InstituteDto> jsonPatchDocument = JsonConvert.DeserializeObject<JsonPatchDocument<InstituteDto>>(requestBody);
                    //Apply patch here
                    jsonPatchDocument.ApplyTo(instituteDto);
                 
                    //Apply the change
                    instituteProvider.UpdateInstitute(instituteDto);
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
               // return Generic Exception here
            }
        }
