    public class CreateUserVm
    {
       public string UserName { set;get; }
       public string Password { set;get; }
       public List<SelectListItem> UserLevels { set; get; }
       public int UserLevelId { set; get; }
    }
