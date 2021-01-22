    private void RemoveRoleHierarchy()
    {
        #if DEBUG
        var departments = _unitOfWork.DepartmentRepository.GetAll().ToList();
        var roleHierarchies = _unitOfWork.RoleHierarchyRepository.GetAll().ToList();
        #endif
        try
        {
            //RoleHierarchy
            foreach (SchoolBo.RoleHierarchy item in _listSoRoleHierarchy.Where(r => r.BusinessKeyMatched == false))
                _unitOfWork.RoleHierarchyRepository.Remove(item.Id);
            _unitOfWork.Save();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.ToString());
            throw;
        }
    }
