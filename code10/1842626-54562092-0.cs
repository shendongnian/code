services.AddGraphQL(sp => Schema.Create(c =>
{
    // Here goes the schema definition which is omitted for brevity purpose
}),
new QueryExecutionOptions
{
    TracingPreference = TracingPreference.Always
});
And yes, it works the same way in .Net Framework. The API in .Net Core and Framework is kept identical let say 99% identical. What here differs is just the surrounding which means the Startup class which wraps the DI configuration.
