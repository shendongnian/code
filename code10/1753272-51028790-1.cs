    public JsonResult Factura(string json)//The json parameter appears as Null
        {
            string result;
            string[] data = JsonConvert.DeserializeObject<string[]>(json);
            if (data != null)
            {
                //Modify the data received json.
                result = "success";
            }
            else
            {
                result = "error";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
