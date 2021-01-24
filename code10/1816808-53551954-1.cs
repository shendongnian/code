	public class ContactsRepository : IContactsRepository
	{
		protected readonly GreyWorldDB_DevEntities _context;
		protected readonly IMapper _mapper;
		protected readonly UserManagement _userManagement;
		
		public ContactsRepository(IMapper mapper, GreyWorldDB_DevEntities context, UserManagement userManagement)
		{
			_mapper = mapper;
			_context = context;
			_userManagement = userManagement;
		}
	}
	
	public class OrganizationRepository : ContactsRepository, IOrganizationRepository
	{
		public OrganizationRepository(IMapper mapper, GreyWorldDB_DevEntities context, UserManagement userManagement)
            : base(mapper, context, userManagement)
		{
		}
	}
