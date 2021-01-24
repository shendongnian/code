      [Route("api/ArticleController/PostArticle")]
        public HttpResponseMessage PostArticle(ArticleModel obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string PhotoPath =        Convert.ToString(ConfigurationManager.AppSettings["ImagePath"]);
                    ArticleModel newObj = new ArticleModel();
                    newObj.Title  = obj.Title ;
                    newObj.Content = obj.Content;
                    newObj.FileName = obj.FileName;
                    newObj.FilePath = obj.FilePath;
                    newObjl.FileLength = obj.FileLength;
                    if (String.IsNullOrEmpty(newObj.Content))
                    {
                    }
                    else
                    {                        
                        string startingFilePath = PhotoPath;
                        string FilePath = SaveImage(newObj.Content, startingFilePath, newObj.FileName);
                        FileInfo fInfo = new FileInfo(FilePath);
                        newObj.Content = fInfo.Name;
                    }
                    ArticleEntities context = new ArticleEntities();
                    var newArticle = context.spInsertArticle(newObj.Title, newObj.Content,
                    newObj.FileName, newObj.FilePath, newObj.FileLength);
                    return Request.CreateResponse(HttpStatusCode.Created, newArticle);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
