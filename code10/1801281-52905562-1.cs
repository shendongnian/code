    public class RoleItem
    {
    	public int Id { get; set; }
    	public string Title { get; set; }
    
    	public override string ToString()
    	{
    		return Title.ToString();
    	}
    }   
    
    private void Page_Load(object sender, EventArgs e)
    {
    	List<RoleItem> _allRoles = new List<RoleItem>()
    	{
    		new RoleItem() {Id =1,Title="Role1"},
    		new RoleItem() {Id =2,Title="Role2"},
    		new RoleItem() {Id =3,Title="Role3"},
    		new RoleItem() {Id =4,Title="Role4"},
    	};
    
    	List<RoleItem> _userRoles = new List<RoleItem>()
    	{
    		new RoleItem() {Id =1,Title="Role1"},
    		new RoleItem() {Id =4,Title="Role4"},
    	};
    
    
    	rolesClbx.DataSource = _allRoles;
    	
    	for(int i=0;i< _allRoles.Count; i++)
    	{
    		if(_userRoles.Any(r => r.Id == _allRoles[i].Id))
    		{
    			rolesClbx.SetItemChecked(i, CheckState.Checked);
    		}
    	}
    }
