        public override void PreInitialize()
        {
            // ...
            IocManager.IocContainer.Register(
                Component.For<IAbpSession, TestAbpSession>()
                    .ImplementedBy<MyTestAbpSession>()
                    .LifestyleSingleton()
                    .IsDefault()
                );
        }
