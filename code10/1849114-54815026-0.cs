    cfg.CreateMap<SourceEvent, Event>()
                    .ForMember(d => d.Student,
                        o => o.MapFrom(
                            s => new Student
                            {
                                StudentId = s.StudentId,
                                StudentName = s.StudentName,
				                Address = new Address	{
					              AddressName = s.AddressName,
					              City = s.City 
                            	 }
                            }));
            });
