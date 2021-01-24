     public void Update(BusinessUnit businessUnit)
        {
            var oldBusinessUnit = _unitOfWork.BusinessUnits.GetById(businessUnit.Id);
            oldBusinessUnit.Name = businessUnit.Name;
            oldBusinessUnit.WindowsGroups.Clear();
            oldBusinessUnit.WindowsLogins.Clear();
            if (businessUnit.WindowsGroups != null)
            {
                var windowsGroupIds = businessUnit.WindowsGroups.Select(x => x.Id).ToList();
                foreach (var winGroup in _unitOfWork.WindowsGroups.Find(winGroup => windowsGroupIds.Contains(winGroup.Id)).ToList())
                {
                    oldBusinessUnit.WindowsGroups.Add(_unitOfWork.WindowsGroups.GetById(winGroup.Id));
                }
            }
            if (businessUnit.WindowsLogins != null)
            {
                var windowsLoginIds = businessUnit.WindowsLogins.Select(x => x.Id).ToList();
                foreach (var winLogin in _unitOfWork.WindowsLogins.Find(winLogin => windowsLoginIds.Contains(winLogin.Id)).ToList())
                {
                    oldBusinessUnit.WindowsLogins.Add(_unitOfWork.WindowsLogins.GetById(winLogin.Id));
                }
            }
            _unitOfWork.Complete();
        }
