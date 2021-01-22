    <% using (Html.BeginForm("AddUser", "Group", new { groupId = Model.GroupID })) { %>
    public ViewResult AddUser(int groupId) {
      //your logic here
      ViewData.Model = new MyModel() {
        GroupID = groupId
      };
      return View();
    }
