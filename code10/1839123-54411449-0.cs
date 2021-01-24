[HttpPost("/api/account"), Authorize]
public void SaveUser([FromForm]UserModel info)
In model:
[FromForm(Name="avatar")]
public IFormFile Avatar { get; set; }
[FromForm(Name="name")]
public string Name { get; set; }
