        public IEnumerable<StemModel> GetStemModelForPlotHeader(int projectParameter, int plotParameter,
            string plantCommunityParameter) =>
            dbConnection.Query<StemModel, PlotSurveyModel, PlantCommunityModel, ProjectModel, SpeciesModel, StemModel>(getAllPlotHeaderDetails,
                (stem, survey, plantCommunity, project, species) =>
                {
                    stem.PlotSurvey = survey;
                    survey.PlantCommunity = plantCommunity;
                    survey.Project = project;
                    stem.Species = species;
                    return stem;
                },
                new
                {
                    ProjectId = projectParameter,
                    PlantCommunityCode = plantCommunityParameter,
                    PlotNumber = plotParameter
                });
