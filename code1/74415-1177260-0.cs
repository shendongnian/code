            ICollection<T> businessObjectList = 
                BusinessContextManagerService.Fetch<ICollection<T>>(Criteria.ActiveAndDormant);
            bool res = true;
            object entityPropertyValue = null;
            // Only Checking one property
            if (entityPropertyName.Length == 1)
            {
                entityPropertyValue = getPropertyValue(entityProperty, entityPropertyName[0]);
                if (businessObjectList.Any(x => getPropertyValue(x, entityPropertyName[0]).Equals(entityPropertyValue) &&
                                           x.GetType().GetProperty("ID").GetValue(x, null).ToString()
                                           != ((IBusinessObjectBase)entityProperty).ID.ToString()))
                    res &= true;
                else
                    res &= false;
            }
            else
            {
                foreach (object obj in businessObjectList)
                {
                    res = true;
                    int objID = (Int32)obj.GetType().GetProperty("ID").GetValue(obj, null);
                    for (int i = 0; i < entityPropertyName.Length; i++)
                    {
                        entityPropertyValue = getPropertyValue(entityProperty, entityPropertyName[i]);
                        object objValue = getPropertyValue(obj, entityPropertyName[i]);
                        if (objValue.Equals(entityPropertyValue) && objID != ((IBusinessObjectBase)entityProperty).ID)
                            res &= true;
                        else
                            res &= false;
                        if (res == false)
                            break;
                    }
                    if (res == true)
                        break;
                }
            }
            if (res)
                return new ValidationError(_DuplicateMessage);
            else
                return ValidationError.Empty;
        }
