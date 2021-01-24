        [HttpPost]
        public IHttpActionResult SaveFileWithData()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                #region Get entity data
                var entity = new EntityClass();
                entity.Name = httpRequest.Params["name"];
                //here you put the saving code into entity framework aka Context.Entity.Add(entity); Context.SaveChanges();
                #endregion
                if (httpRequest.Files.Count > 0)
                {
                    var myFile = httpRequest.Files[0];
                    var filePath = HttpContext.Current.Server.MapPath($"~/Files/{ myFile.FileName}");
                    //Set the file into server
                    myFile.SaveAs(filePath);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
