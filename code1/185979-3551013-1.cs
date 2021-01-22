    public partial class admin_CadUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtUsuarios = DBManager.RunSqlGetDataTable(
              @"select b.UserName, c.Email, c.IsLockedOut, c.LastLoginDate, 
                  case 
                    when e.RoleName is not null then 1
                    else 0 end Admin
                from dbo.aspnet_Applications a join dbo.aspnet_Users b
                  on a.ApplicationId = b.ApplicationId
                join dbo.aspnet_Membership c
                  on b.ApplicationId = c.ApplicationId
                  and b.UserId = c.UserId
                left join dbo.aspnet_UsersInRoles d
                  on d.UserId = b.UserId
                left join dbo.aspnet_Roles e
                  on d.RoleId = e.RoleId
                where a.ApplicationName = 'Mont Blanc Catalogo'");
            DataView dvUsuarios = new DataView(dtUsuarios) { Sort = "UserName" };
            gdvUsuarios.DataSource = dvUsuarios;
            gdvUsuarios.DataBind();
        }
    
        protected void gdvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Nome Usuário";
                e.Row.Cells[1].Text = "E-mail";
                e.Row.Cells[2].Text = "Bloqueado";
                e.Row.Cells[3].Text = "Último Login";
                e.Row.Cells[4].Text = "Administrador";
            }
        }
    }
