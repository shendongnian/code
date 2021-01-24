     using (var scope = Configuration.Modules.AbpConfiguration.IocManager.CreateScope())
     {
         var suiteRepository = scope.ResolveAsDisposable<IRepository<Source2>>();
         config.CreateMap<Source1, Destination>()
              .ForMember(u => u.Name, options => options.ResolveUsing(new CustomResolver(suiteRepository.Object)));
     }
