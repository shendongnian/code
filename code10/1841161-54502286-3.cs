    [HttpPost]
            public ActionResult Create()
            {
                string serializedRegisterData = Request["RegisterData"]; //you can do code of deserialization for form data.
                var image= Request.Files[0];
                var imagePath = Path.GetFileName(image.FileName);
                return Json("");
            }
