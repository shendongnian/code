            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ParentChildDTO, Parent>()
                    .ConstructUsing(item => new Parent
                    {
                        Children = new List<Child>
                        {
                            new Child
                            {
                                ChildId = item.ChildId,
                                ChildName = item.ChildName
                            }
                        }
                    });
            });
