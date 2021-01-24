    EmailSetting option = new EmailSetting();
                //You need to bind the section with data model, 
                //it will automatically map config key to property of model having same name
                config.GetSection("EmailSettings").Bind(option);
    
                //Alternative to this you can read nested key using below syntax
                var emailTemplatesPath = config["EmailSettings:EmailTemplatesPath"];
                var emailInEmailSettings = config["EmailSettings:Email"];
                // If email key is not nested then you can access it as below
                var email = config.GetValue<string>("EmailOutside");
