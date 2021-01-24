     c.CreateMap<A, B>()
        .ForMember(dest => dest.Items, opt => opt.ResolveUsing(src =>
        {
           if (src.Items["param1"] == true)
           {
               // Do whatever
           }
    
           return /*do whatever else*/;
        }));
