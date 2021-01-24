    using Newtonsoft.Json;
    // Look up people in SPO column Members and try to add them to the newly created group
    string membersPull = item.Fields.AdditionalData["_x010c_lenov_x00e9_t_x00fd_mu"].ToString();
    string ownersPull = item.Fields.AdditionalData["SpravciTymu"].ToString();
    //on the very bottom, there is another class utilizing this JSON extraction
    var members = JsonConvert.DeserializeObject<List<Receiver>>(membersPull);
    var owners = JsonConvert.DeserializeObject<List<Receiver>>(ownersPull);
    foreach (var member in members)
    {
	 var memberUPN = member.Email;
	 Console.ForegroundColor = ConsoleColor.Yellow;
	 Console.WriteLine("Adding user: " + member.Email);
	 Console.ResetColor();
	 try
	 {
		 var addMember = await graphServiceClient.Users[memberUPN].Request().Select("id").GetAsync();
		 await graphServiceClient.Groups[groupID].Members.References.Request().AddAsync(addMember);
	 }
	 catch
	 {
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine("USER " + memberUPN + "is already MEMBER of: " + group2.DisplayName);
		Console.ResetColor();
	 }
    }
