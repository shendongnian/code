class ClientRole
{
    public int ClientId { get; set; }
    public string Role { get; set; }
    public int RowVersion { get; set; }
}
Try this:
var clientRoles = new List<ClientRole>
{
    new ClientRole { ClientId = 101, Role = "READ", RowVersion = 2 },
    new ClientRole { ClientId = 101, Role = "WRITE", RowVersion = 1 },
    new ClientRole { ClientId = 102, Role = "ADMIN", RowVersion = 2 },
    new ClientRole { ClientId = 102, Role = "OTHER", RowVersion = 12 }
};
var clientRolesDic = (
    from cr in clientRoles
    group cr by cr.ClientId into g
    select g.OrderByDescending(i => i.RowVersion).First()
    )
    .ToDictionary(k => k.ClientId);
