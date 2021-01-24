        public IReadOnlyList<UserActivity> GetListOfUserActivities()
        {
            List<UserActivity> userActivities = _activityDataAccess.GetActivities().ConvertAll(act => _mapper.Map<UserActivity>(act)).ToList();
            userActivities.ForEach(ua => ua.Parent = this);
            return userActivities;
        }
