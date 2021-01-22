    [global::System.Data.Linq.Mapping.FunctionAttribute()]
    public ISingleResult<uspGetDepartmentsResult> uspGetDepartments()
    {
        IExecuteResult result = this.ExecuteMethodCall(
            this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        return ((ISingleResult<uspGetDepartmentsResult>)(result.ReturnValue));
    }
