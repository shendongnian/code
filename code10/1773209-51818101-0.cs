        private SqlConnection GetConnection()
        {
            return new SqlConnection("ConnectionString");
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync(int type)
        {
            using (var connection = GetConnection())
            {  
                DynamicParameters param = new DynamicParameters();
                    param.Add("@type", type);
                var result = await connection.QueryAsync<Student>("[dbo].[StudentController_GetStudents]",param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
      public async Task<IEnumerable<Teacher>> GetTeachersAsync(int type)
        {
            using (var connection = GetConnection())
            {  
                DynamicParameters param = new DynamicParameters();
                    param.Add("@type", type);
                var result = await connection.QueryAsync<Student>("[dbo].[StudentController_GetTeachers]",param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    UpdateStudents(await StudentDao.GetStudentsAsync(type));
    UpdateTeachers(await StudentDao.GetTeachersAsync(type));
