    string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <RoleManagement xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
      <Permissions>
        <Group Name=""Test Case Management"">
          <Permission ID=""1"" Name=""Add/Edit/Delete test cases"" />
          <Permission ID=""2"" Name=""Assign Test cases to users"" />
        </Group>
        <Group Name=""Bug Management"">
          <Permission ID=""9"" Name=""Add/Edit/Delete bugs"" />
          <Permission ID=""13"" Name=""View bugs"" />
        </Group>
        <Group Name=""Administration"">
          <Permission ID=""19"" Name=""Database backup"" />
          <Permission ID=""20"" Name=""Role Management"" />
        </Group>
      </Permissions>
      <RolePermissions>
        <RolePermission RedmineId=""8"" PermissionID=""9"" />
        <RolePermission RedmineId=""8"" PermissionID=""13"" />
      </RolePermissions>
      <Roles>
        <Role Name=""Manager"" RedmineId=""8"" TestlinkId=""15"" />
      </Roles>
    </RoleManagement>";
    RoleManagement roleManagement;
    // convert string to stream
    byte[] byteArray = Encoding.UTF8.GetBytes(xml);
    using (MemoryStream stream = new MemoryStream(byteArray))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(RoleManagement));
        using (XmlReader reader = XmlReader.Create(stream))
        {
            roleManagement = (RoleManagement)serializer.Deserialize(reader);
        }
    }
