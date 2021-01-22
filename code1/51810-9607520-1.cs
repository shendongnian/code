		partial void OnValidate(System.Data.Linq.ChangeAction action)
		{
			if (action == System.Data.Linq.ChangeAction.Insert)
			{
				CreatedBy = CurrentUserID;
				CreatedOn = DateTime.Now;
				LastUpdatedBy = CreatedBy;
				LastUpdatedOn = CreatedOn;
			}
			else if (action == System.Data.Linq.ChangeAction.Update)
			{
				LastUpdatedBy = CurrentUserID;
				LastUpdatedOn = DateTime.Now;
			}
		}
