    public sealed class UserMap : ClassMap<User>, IMapGenerator
    	{
    		public UserMap()
    		{ 
    			Id(x => x.Id)
    				.WithUnsavedValue(0);
    			Map(x => x.Username).TheColumnNameIs("UserName");
    			Map(x => x.Password).TheColumnNameIs("Password");	
    			Map(x => x.Salt).ReadOnly();
    
    			Map(x => x.CreatedOn).ReadOnly();
    			Map(x => x.CreatedBy).ReadOnly();
    			Map(x => x.CreatedAt).ReadOnly();
    
    			Map(x => x.ApprovalStatus)
    				.TheColumnNameIs("ApprovalStatusId")
    				.CustomTypeIs(typeof(ApprovalStatus));
    
    			Map(x => x.DeletionStatus)
    				.TheColumnNameIs("DeletionStatusId")
    				.CustomTypeIs(typeof(DeletionStatus));
    
    			References(x => x.Role).Not.Nullable();
    			References(x => x.Contact);
    
    		}
    
    		#region IMapGenerator Members
    
    		public System.Xml.XmlDocument Generate()
    		{
    			return CreateMapping(new MappingVisitor());
    		}
    
    		#endregion
    	}
