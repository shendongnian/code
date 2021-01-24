    public MainViewModel()
    {     
      DisplayName = "Plan2Fit";
      Items.Add(new CreatePlanViewModel(_exerciseProviderViewModel));
      Items.Add(new ExerciseManagementViewModel(_exerciseProviderViewModel));
    }
