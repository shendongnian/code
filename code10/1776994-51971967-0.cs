         foreach (var sticker in data)
         {
                var entity = new IntermediaryAssignment();
                entity.CompanyCode = sticker.CompanyCode;
                entity.StickerCode = sticker.StickerCode;
                entity.RegistrationNumber = intermediary.RegistrationNumber;
                entity.Status = EntityStatus.Active;
                entity.CreatedDate = DateTime.Now;
                entity.Dispatched = false;
                entity.IntermediaryType = intermediary.IntermediaryType;
                dbSet.Add(entity);
            }
