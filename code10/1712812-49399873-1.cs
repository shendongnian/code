     public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.EnableSwagger();
            var webApiConfiguration = WebApiConfig.Register(config);
            //here I commented other startup code
        }
