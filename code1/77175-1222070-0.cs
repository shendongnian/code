    CheckBoxList chklRoles = (CheckBoxList)frm.FindControl("chklRoles");
        foreach (ListItem liRole in chklRoles.Items)
        {
            if (liRole.Selected)
            {
                SecurityDS.SC_RoleRow drwRoles = dtblRoles.NewSC_RoleRow();
                drwRoles.Name = liRole.Value;
                drwRoles.IsActive = false;
                dtblRoles.Rows.Add(drwRoles);
            }
        }
        e.Values["userRole"] = dtblRoles;
    <InsertParameters>
                     
                        <asp:Parameter Name="userRole" Type="Object" />
                    </InsertParameters>
