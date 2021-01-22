    public global::System.Data.Objects.ObjectResult<DepartmentDataEntityType> GetPersonelInformationWithDepartmanID(global::System.String departmentName)
    {
        global::System.Data.Objects.ObjectParameter departmentNameParameter;
        departmentNameParameter = new global::System.Data.Objects.ObjectParameter("departmentNameParameter", departmentName);
    
        return base.ExecuteFunction<DepartmentDataEntityType>("sp_GetDepartmanData", departmentNameParameter);
    }
