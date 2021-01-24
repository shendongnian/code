    [HttpPost]
            [Route("UserInfo")]
            public async Task<IHttpActionResult> SetUserInfo()
            {
                NameValueCollection form = HttpContext.Current.Request.Form;
                var model = Pawmapper<UserViewModel>.Map(form, new UserViewModel());
    
                var user = UserManager.FindByName(User.Identity.Name);
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.Skype = model.Skype;
                user.PhoneNumber = model.PhoneNumber;
    
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    model.Avatar = HttpContext.Current.Request.Files["Avatar"];
                    var photoId = Guid.NewGuid() + Path.GetExtension(model.Avatar.FileName);
    
                    user.Photo = new DataProvider.Photo
                    {
                        FileName = model.Avatar.FileName,
                        Path = "app/modules/main/img/users/" + photoId
                    };
    
                    model.Avatar.SaveAs(HttpContext.Current.Server.MapPath("~/Client/app/modules/main/img/users/" + photoId));
                }
    
                var result = await UserManager.UpdateAsync(user);
    
                if (!result.Succeeded)
                {   
                    return GetErrorResult(result);
                }
    
                return Ok();
            }
