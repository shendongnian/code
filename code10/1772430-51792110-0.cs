     public override Task<MyEntityDto> Create(MyEntityDto input)
            {
                //...
                var uteams = _userTeamsRepository.GetAllIncluding(x=>x.User).Where(ut => ut.Team.Id == teamId).ToList();
                //and you need to map uteams to your DTO list. 
                //var uteamsDto = uteams.MapTo<List<MyTeamDto>>();
                //...
            }
