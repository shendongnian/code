     public static void WriteJSONObject(this HttpResponse response, object content) {
                response.ContentType = "application/json";
                response.Write(new JavaScriptSerializer().Serialize(content));
                response.End();
    
     }
