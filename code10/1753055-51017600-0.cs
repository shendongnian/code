	public JobsOutPut GetJobs(List<string> types, string country)
	{
		//Getting the jobs here
		var jobs =
		(
			from row in _jobCategoryRepository.GetAll().ToList()
			join rowT in _jobTypeRepository.GetAll().ToList() on row.JobId equals rowT.JobId
			let jobDto = new JobDto
			{
				Id = row.JobId,
				Title = row.Job.Title,
			}
			where jobDto.Country.Contains(country)
			where !types.Any() || types.Any(t => jobDto.TypeName == t)
			orderby row.CreationTime descending
			select jobDto
		);
	
		return new FilterJobOutPut
		{
			JobsList = jobs.ToList(),
		};
	}
