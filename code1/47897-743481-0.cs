    public CMS.ProductVariant GetProductVariantById(int id)
		{
			ProductVariant pv = null;
			if (id > 0)
			{
				using (db = new CmsEntity())
				{
					pv = db.ProductVariant.Where(v => v.Id == id).FirstOrDefault();
					db.Detach(pv); 
				}
			}
			return pv;
		}
