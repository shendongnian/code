    [Route("{id}")]
    [HttpGet]
    public TeacherDto GetTeacher(int  id/* or other type if you aren't using int as your primary key*/ )
    {
        return _currentTeacherProcess.GetTeacher(id);
    }
