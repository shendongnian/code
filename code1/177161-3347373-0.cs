     var query = inventoryRepository.ObjectSet
                    .Include("ProductDescriptions")
                    .Include("ProductAllowedWarehouses")
                    .Include("ProductToCategories")
                    .Include("PriceLevels")
                    .Include("AttachmentAssociations.Attachment").AsExpandable()
                    .Where(wherePredicate)
                    .Where(a=>a.ProductDescriptions.Languages.AlternateCode.Equals("en", StringComparison.CurrentCultureIgnoreCase);
