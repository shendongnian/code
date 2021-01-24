     catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var jsonObject = JsonConvert.SerializeObject(My Custom Model);
            await context.Response.WriteAsync(jsonObject, Encoding.UTF8);
            context.Response.Body.Seek(0, SeekOrigin.Begin);    //IMPORTANT!
            await responseBody.CopyToAsync(originalBodyStream); //IMPORTANT!
            return;
        }
