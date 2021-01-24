        public IEnumerable<SpeciesModel> GetAllSpecies() => dbConnection
            .Query<SpeciesModel, SpeciesCategoryModel, SpeciesTypeModel, WetlandIndicatorModel, SpeciesModel>(getAllSpeciesQuery,
                (species, speciesCategory, speciesType, wetlandIndicator) =>
                {
                    species.SpeciesCategory = speciesCategory;
                    species.SpeciesType = speciesType;
                    species.WetlandIndicator = wetlandIndicator;
                    return species;
                });
