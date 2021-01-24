    public class EmailInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IResolveApplicationPath))
                    .ImplementedBy(typeof(ApplicationPathResolver))
                    .LifeStyle.PerWebRequest);
            container
                .Register(Component.For(typeof(IGenerateEmailMessage)).ImplementedBy(typeof(EmailMessageGenerator))
                    .LifeStyle
                    .PerWebRequest);
            container
                .Register(Component.For(typeof(ISendEmail)).ImplementedBy(typeof(EmailSender))
                    .LifeStyle
                    .PerWebRequest);
            container.Register(
                Component.For<NotificationConfigurationSection>()
                    .UsingFactoryMethod(
                        kernel =>
                            kernel.Resolve<IConfigurationManager>()
                                .GetSection<NotificationConfigurationSection>("notificationSettings")));
        }
    }
