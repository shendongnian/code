public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<MediatorModule>();
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                }
            );
}
