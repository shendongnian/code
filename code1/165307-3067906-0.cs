    partial class MyAdminEntity : EntityBase
    {
      internal override OnSaving(ChangeAction changeAction)
      {
        if (changeAction == ChangeAction.Insert)
        {
          CreatedBy = "<username>";
          CreatedDate = DateTime.Now;
        }
        else if (changeAction == ChangeAction.Update)
        {
          CreatedBy = "<username>";
          CreatedDate = DateTime.Now;
        }
      }
    }
