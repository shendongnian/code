            // Get the collection (or create, if doesn't exist)
            LiteCollection<YacksProjectInfo> yacksProjects = 
                                      liteDatabase.GetCollection<YacksProjectInfo>("YacksProjects");
	
            // Index (current and future) documents using ProjectName and ModuleNumber properties
            yacksProjects.EnsureIndex((YacksProjectInfo x) => x.ProjectName, true);
            yacksProjects.EnsureIndex((YacksProjectInfo x) => x.ModuleNumber, true);
