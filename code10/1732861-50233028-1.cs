    CreateMap<SourceEntity, DestinationEntity>()
    	.ForMember(dest => dest.Type1_PhoneSelected, opt => opt.ResolveUsing(new YourCustomResolver(Communication.Phone), src => src.SelectedCommunication))
    	.ForMember(dest => dest.Type1_EmailSelected, opt => opt.ResolveUsing(new YourCustomResolver(Communication.Email), src => src.SelectedCommunication))
    	.ForMember(dest => dest.Type1_PostSelected , opt => opt.ResolveUsing(new YourCustomResolver(Communication.Post) , src => src.SelectedCommunication))
    	.ForMember(dest => dest.Type2_PhoneSelected, opt => opt.ResolveUsing(new YourCustomResolver(Communication.Phone), src => src.SelectedCommunication))
    	.ForMember(dest => dest.Type2_EmailSelected, opt => opt.ResolveUsing(new YourCustomResolver(Communication.Email), src => src.SelectedCommunication))
    	.ForMember(dest => dest.Type2_PostSelected , opt => opt.ResolveUsing(new YourCustomResolver(Communication.Post) , src => src.SelectedCommunication));
