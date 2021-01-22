    public static class MyExtenstionMethods 
    {   
      public static bool HasSelectedValue(this RadioButtonList list) 
      {
        return list.SelectedItem != null;
      }
    }
    ...
    if (RadioButtonList_VolunteerType.HasSelectedValue)
    {
     // do stuff
    }
