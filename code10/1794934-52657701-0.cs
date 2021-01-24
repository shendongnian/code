    public PlanClientService()
        {
            _serviceClient = GraphSdkHelper.GetGraphServiceClient();
        }
        public async Task<IList<PlannerPlan>> PlannerPlansAsync()
        {
            var plans = await _serviceClient.Me.Planner.Plans.Request().GetAsync();
            return plans;
        }
