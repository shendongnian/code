    private void InitializeMapper()
        {
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile<MyProfile>();
                });
            }
            catch
            {
            }
        }
