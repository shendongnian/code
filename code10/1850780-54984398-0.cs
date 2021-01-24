     catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var jsonObject = JsonConvert.SerializeObject(My Custom Model);
            await context.Response.WriteAsync(jsonObject, Encoding.UTF8);
            return;
        }
