    public partial class ValidationRule
    {
        public void Run<T>(Ctx context, List<ForecastViewModel> entity)
            where T : class, INewReleaseValidationEntity
        {
            var execution = (T)Activator.CreateInstance<T>();
            execution.Run(context, entity.ToArray());
        }
    }
   
