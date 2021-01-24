                using (var scope = container.BeginLifetimeScope())
                {
                    //Select this one specific job by its metadata.
                    var specificJobInitializer = scope
                        .Resolve<IEnumerable<Meta<Func<IJob>, JobMetadata>>>()
                        .Single(jobInitializer => jobInitializer.Metadata.Type == jobDefinition.Type);
                    IJob job = specificJobInitializer.Value();
                    job.Run();
                }
