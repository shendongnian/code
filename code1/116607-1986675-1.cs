        public ActionResult Save()
        {
            string json = Request.Form[0];
            var serializer = new DataContractJsonSerializer(typeof(JsonItem));
            var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json));
            JsonItem item = (JsonItem)serializer.ReadObject(memoryStream);
            memoryStream.Close();
            SaveItem(item);
            return Content("success");
        }
