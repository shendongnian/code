    public static class Events
    {
      public static BtnDeleteSelected_Click(object sender, EventArgs e)
      {
        ExecuteGvMethod(UserGvUtil.DeleteSelectedUsersAndProfiles, (GridView)sender, "hi of whatever");
      }
    }
