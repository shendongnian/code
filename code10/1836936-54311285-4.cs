    var rankings = new List<Rankings> {
        new Rankings{  JOB_ID= 4,EMPLOYEE_ID= 3, OVERALL_SCORE=  800 },
        new Rankings{  JOB_ID= 4,EMPLOYEE_ID= 4, OVERALL_SCORE=  800 },
        new Rankings{  JOB_ID= 3,EMPLOYEE_ID= 1, OVERALL_SCORE=  800 },
        new Rankings{  JOB_ID= 3,EMPLOYEE_ID= 2, OVERALL_SCORE= 1200 },
        new Rankings{  JOB_ID= 2,EMPLOYEE_ID= 1, OVERALL_SCORE= 1600 },
        new Rankings{  JOB_ID= 2,EMPLOYEE_ID= 2, OVERALL_SCORE= 1800 },
        new Rankings{  JOB_ID= 4,EMPLOYEE_ID= 1, OVERALL_SCORE= 2000 },
        new Rankings{  JOB_ID= 4,EMPLOYEE_ID= 2, OVERALL_SCORE= 2100 },
        new Rankings{  JOB_ID= 1,EMPLOYEE_ID= 1, OVERALL_SCORE= 6400 },
    };
    var cpy = new List<Rankings>(rankings);
    var result = new List<Rankings>();
    while (cpy.Count() > 0)
    {
        var first = cpy.First();
        result.Add(first);
        cpy.RemoveAll(r => r.EMPLOYEE_ID == first.EMPLOYEE_ID || r.JOB_ID == first.JOB_ID);
    }
