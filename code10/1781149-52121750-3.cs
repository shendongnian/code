    public static Guid AddPlanItem(PlanItemAddViewModel viewModel, IEnumerable<HttpPostedFileBase> images)
    {
        Guid planIdGUID = Guid.NewGuid();
        using (var context = new ApplicationDbContext())
        {
            PlanItem planItem = context.Plans.Create();
            planItem.PlanId = planIdGUID;
            planItem.CreateDate = DateTime.Now;
            planItem.PlanIdTitle = viewModel.PlanIdTitle;
            planItem.PlanTitle = viewModel.PlanTitle;
            planItem.SolutionTitle = viewModel.SolutionTitle;
            planItem.ActivityCodeId = viewModel.ActivityCodeId;
            planItem.RegionId = viewModel.RegionId;
            planItem.OperatingCenterId = viewModel.OperatingCenterId;
            planItem.DistrictId = viewModel.DistrictId;
            planItem.ServiceCenterId = viewModel.ServiceCenterId;
            planItem.PlannerRACFId = viewModel.PlannerRACFId;
            planItem.SeverityId = viewModel.SeverityId;
            planItem.Description = viewModel.Description;
            planItem.PreviousPlan = viewModel.PreviousPlan;
            context.Plans.Add(planItem);
            context.SaveChanges();
        }
        return planIdGUID;
    }
