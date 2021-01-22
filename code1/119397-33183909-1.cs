    public IHttpActionResult UpdatePhysicianImage(HttpRequestMessage request)
        {
            try
            {
                var form = HttpContext.Current.Request.Form;
                var model = JsonConvert.DeserializeObject<UserPic>(form["json"].ToString());
                bool istoken = _appdevice.GettokenID(model.DeviceId);
                if (!istoken)
                {
                    statuscode = 0;
                    message = ErrorMessage.TockenNotvalid;
                    goto invalidtoken;
                }
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        // var filePath = uploadPath + postedFile.FileName;
                        //  string fileUrl = Utility.AbsolutePath("~/Data/User/" + model.UserId.ToString());
                        string fileUrl = Utility.AbsolutePath("~/" + Utility.UserDataFolder(model.UserId, "Document"));
                        if (!Directory.Exists(fileUrl))
                        {
                            Directory.CreateDirectory(fileUrl);
                            Directory.CreateDirectory(fileUrl + "\\" + "Document");
                            Directory.CreateDirectory(fileUrl + "\\" + "License");
                            Directory.CreateDirectory(fileUrl + "\\" + "Profile");
                        }
                        string imageUrl = postedFile.FileName;
                        string naviPath = Utility.ProfileImagePath(model.UserId, imageUrl);
                        var path = Utility.AbsolutePath("~/" + naviPath);
                        postedFile.SaveAs(path);
                        docfiles.Add(path);
                        if (model.RoleId == 2)
                        {
                            var doctorEntity = _doctorProfile.GetNameVideoChat(model.UserId);
                            doctorEntity.ProfileImagePath = naviPath;
                            _doctorProfile.UpdateDoctorUpdProfile(doctorEntity);
                        }
                        else
                        {
                            var patientEntity = _PatientProfile.GetPatientByUserProfileId(model.UserId);
                            patientEntity.TumbImagePath = naviPath;
                            _PatientProfile.UpdatePatient(patientEntity);
                        }
                    }
                    result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception e)
            {
                statuscode = 0;
                message = "Error" + e.Message;
            }
        invalidtoken:
            return Json(modeldata.GetData(statuscode, message));
        }
