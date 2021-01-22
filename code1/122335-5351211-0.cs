    private bool HasUserPublicGravatar(string email)
        {
            try
            {
                var gravatarPath = GravatarService.GetGravatarUrlForAddress(email,
                new GravatarUrlParameters { DefaultOption = GravatarDefaultUrlOptions.Error });
                WebRequest wReq = HttpWebRequest.Create(gravatarPath);
                var wRes = wReq.GetResponse();
                return true;
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("404"))
                    return false;
                else
                    throw new Exception("Couldn't determine if ueser has public avatar");
            }
        }
