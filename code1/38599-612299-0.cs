    partial void OnValidate(System.Data.Linq.ChangeAction action)
		{
			//All content items need titles
			if (Description == null || Description == "")
				throw new Exception("The description field is empty!");
			//Content types of image need...images
			if (ContentItemTypeId == (int)ContentItemTypes.Image && ImageData == null)
				throw new Exception("An image is required in order to save this content item!");
			//New Content Items don't have ids.  If a new one comes through, set the default values for it.
			if (this.ContentItemId == 0)
			{
				this.CreatedOn = DateTime.Now;
				this.LastUpdatedOn = DateTime.Now;
				this.IsDeletable = true;
			}
		}
