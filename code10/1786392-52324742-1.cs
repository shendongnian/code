    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Create mapping within profile in constructor
            CreateMap<ParametroCreateViewModel, Parametro>()
                // ignore both unmapped properties
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TipoDato, opt => opt.Ignore())
                .ReverseMap();
        }
    }
    [Test]
    public void AutoMapperAutofacTest()
    {
        // Arrange
        var builder = new ContainerBuilder();
            
        // load certain assembly
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AutoMapperConfig)))
                .AssignableTo<Profile>()
                .As<Profile>(); // register as profile
        builder.Register(c => new MapperConfiguration(cfg =>
        {
            foreach (var profile in c.Resolve<IEnumerable<Profile>>())
            {
                cfg.AddProfile(profile);
            }
        })).AsSelf().SingleInstance();
        builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        var container = builder.Build();
            
        var mapper = container.Resolve<IMapper>();
        var param = new Parametro();
        var viewModel = new ParametroCreateViewModel
        {
            Nombre = "Nombre",
            TipoDatoId = 1
        };
        // Act
        mapper.Map(viewModel, param);
        //Assert
        Assert.AreEqual(param.TipoDatoId, 1);
        Assert.AreEqual(param.Nombre, "Nombre");
    }
