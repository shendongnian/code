    public async Task<dynamic> Get(int id)
    {
    	var strQuery = $"SELECT * FROM AuditFormDto INNER JOIN AuditDto ON  AuditDto.Guid = AuditFormDto.AuditDtoGuid where AuditFormDto.Id = {id}";
    	var joinedClass = await _connection.QueryAsync<JoinedClass>(strQuery);
    	return joinedClass;
    }
