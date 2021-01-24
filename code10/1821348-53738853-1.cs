    [HttpPost]
     
        public ActionResult SaveVideo(Video data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var uplodedFile = data.File;
                 //you will get file path from this object property.
                //do other work here
             }
             catch(Exception e){throw;}
        } 
