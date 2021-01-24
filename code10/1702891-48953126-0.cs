     AutoMapper.Mapper.Initialize(map =>
                {
                    var asmEntities = Assembly.Load("DomainLibrary");
                    var asmDtos = Assembly.Load("ViewModelsLibrary");
    
                    foreach (Type entity in asmEntities.GetTypes())
                    {
                        var vm = asmDtos.GetTypes().FirstOrDefault(x => x.Name == $"{entity.Name}Vm");
                        if (vm != null)
                        {
                            map.CreateMap(entity, vm).ReverseMap();
                        }
                    }
    }
      //  exemple names: 
    
    Entity = Product
    ViewModel = ProductVm
