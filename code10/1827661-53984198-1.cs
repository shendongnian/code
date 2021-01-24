            builder.RegisterType<DefaultDatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<NewsletterUnitOfWork>()
                .AsSelf()
                .As<INewsletterUnitOfWork>()
                .InstancePerLifetimeScope();
