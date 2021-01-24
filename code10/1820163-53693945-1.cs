     using (var repo = Configuration.Modules.AbpConfiguration.IocManager.CreateScope().ResolveAsDisposable<IRepository<Source2>>())
     {
         
         config.CreateMap<Source1, Destination>()
              .ForMember(u => u.Name, options => options.ResolveUsing(new CustomResolver(repo.Object)));
     }
