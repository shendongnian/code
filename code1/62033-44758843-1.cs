    using (ClientContext context = new ClientContext("Your Link goes here."))
    {
    	context.Credentials = new System.Net.NetworkCredential("Your User Name", "Your Password", "Domain name");
    	GroupCollection groupCollection = context.Web.SiteGroups;
    	context.Load(groupCollection, groups => groups.Include(group => group.Title, group => group.Id, group => group.Users));
    	context.ExecuteQuery();
    	Group myGroup = groupCollection.GetByName(OldGroupNameTB.Text);
    	context.Load(myGroup);
    	context.ExecuteQuery();
    	
    	List myGroupList = context.Web.SiteUserInfoList;
    	context.Load(myGroupList.Fields);
    	context.ExecuteQuery();
    	
    	FieldMultiLineText text = (FieldMultiLineText)context.Web.SiteUserInfoList.Fields[7];
    	ListItem groupItem = context.Web.SiteUserInfoList.GetItemById(myGroup.Id);
    
    	myGroup.Title = NewGroupNameTB.Text;
    	groupItem[text.InternalName] = GroupDescrioptionTB.Text;
    	
    	groupItem.Update();
    	myGroup.Update();
    	context.ExecuteQuery();
    }
