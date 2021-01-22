public ActionResult ListUsers(int? page, int? pageSize) {
  int totalItems;
  var members = Membership.GetAllUsers(page ?? 0, pageSize ?? 50, out totalItems);
  ViewData["Users"] = ToList<MembershipUser>(members);
  // a second variable
  var members2 = Membership.GetAllUsers();
  ViewData["Users2"] = ToList<MembershipUser>(members2).AsPagination(page ?? 1, 50);
  return View();
}</pre>
