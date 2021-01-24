    public void Update(BusinessUnit businessUnit)
            {
                var oldBusinessUnit = _unitOfWork.BusinessUnits.GetById(businessUnit.Id);
    
                oldBusinessUnit.Name = businessUnit.Name;
                oldBusinessUnit.WindowsGroups.Clear();
                oldBusinessUnit.WindowsLogins.Clear();
    
                if (businessUnit.WindowsGroups != null)
                {
                    foreach (var winGroup in businessUnit.WindowsGroups)
                    {
                        oldBusinessUnit.WindowsGroups.Add(_unitOfWork.WindowsGroups.GetById(winGroup.Id));
                    }
                }
    
                if (businessUnit.WindowsLogins != null)
                {
                    foreach (var winLogin in businessUnit.WindowsLogins)
                    {
                        oldBusinessUnit.WindowsLogins.Add(_unitOfWork.WindowsLogins.GetById(winLogin.Id));
                    }
                }
    
                _unitOfWork.Complete();
            }
