        protected void Application_Start()
        {
            RegisterMaps();
        }
        private void RegisterMaps()
        {
            WebAutoMapperSettings.Register();
            BusinessLogicAutoMapperSettings.Register();
        }
