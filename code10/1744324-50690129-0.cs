            AutodiscoverService adService = new AutodiscoverService(ExchangeVersion.Exchange2013_SP1);
            adService.Credentials = new NetworkCredential("user@d.com", "pass");
            adService.RedirectionUrlValidationCallback = adAutoDiscoCallBack;
            List<String> Users = new List<string>();
            Users.Add("user1@domain.com");
            Users.Add("user2@domain.com");
            GetUserSettingsResponseCollection usrSettings = adService.GetUsersSettings(Users, UserSettingName.UserDisplayName);
            foreach(GetUserSettingsResponse usr in usrSettings)
            {
                Console.WriteLine(usr.Settings[UserSettingName.UserDisplayName]);
            }
