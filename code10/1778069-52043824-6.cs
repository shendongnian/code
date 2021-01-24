    using Microsoft.AspNetCore.Mvc;
    using System.Text.Json;
    //get key(s) and error message(s) from the ModelState
	var serializableModelState = new SerializableError(ModelState);
    //convert to a string
	var modelStateJson = JsonConvert.SerializeObject(serializableModelState);
    //log it
	logger.LogInformation("Bad Model State", modelStateJson);
