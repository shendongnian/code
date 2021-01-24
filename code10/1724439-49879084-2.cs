    var map1 = CreateMap<DesireDto, Desire>();
    var map2 = CreateMap<ProductDto, Product>();
     
    foreach (var s in new []{nameof(DesireDto.CreationDate),nameof(DesireDto.ModifiedDate),nameof(DesireDto.ModifiedUser),nameof(DesireDto.CreationUser),nameof(DesireDto.Language)})
    {
       map1.ForMember(s,x=>x.Ignore()) ;
       map2.ForMember(s,x=>x.Ignore()) ;
    }
