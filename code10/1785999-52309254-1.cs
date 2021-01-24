    static readonly string _divider = ",";
    
    static readonly Dictionary<string, (string header, Func<Employee, string[]> employee)> _configurations
                = new Dictionary<string, (string, Func<Employee, string[]>)>() {
                    ["code1"] = ("FirstName,LastName,SSN,AppStartDate,AppDOB",
                            employee => new string[] {
                                        employee.FirstName,
                                        employee.LastName,
                                        employee.SSN,
                                        employee.StartDate,
                                        employee.DOB }),
                    ["code2"] = ("EMP_FIRST_NAME,EMP_LAST_NAME,EMP_SSN,EMP_DOB,EMP_JOB_START_DATE,PREV_EMPLOYED_BY_EMPLOYER",
                            employee => new string[] {
                                        employee.FirstName,
                                        employee.LastName,
                                        employee.SSN,
                                        employee.DOB,
                                        employee.StartDate,
                                        employee.PreviousEmployee ? "Y" : "N" })
                        //...
                    };
    
    private string GetCSVResult( string code, List<Employee> employees )
            => _configurations[code].header
                + Environment.NewLine
                + employees.Select( e => _configurations[code]
                                         .employee( e )
                                         .Join( _divider ) )
                           .Join( Environment.NewLine );
