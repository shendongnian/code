    public static FilterBase FilterFromPath(this Site activeSite, string filterPath)
        {
            //"Catalog Filters\Default Filters\SP3D Report Filters\Types of Reports\Equipment\Equipment Material Take-Off"            
            Checks.IsNotNull(() => activeSite.ActivePlant);
            FilterFolder currentFolder = null;
            string plantFilters = CmnLocalizer.GetString(CmnResourceIDs.CmnFilterPlantFiltersFolder, "Plant Filters");
            string catalogFilters = CmnLocalizer.GetString(CmnResourceIDs.CmnFilterCatalogFiltersFolder, "Catalog Filters");
        
            if (filterPath.StartsWith(plantFilters))
                currentFolder = activeSite.ActivePlant.PlantModel.Folders[0] as FilterFolder;
            else if (filterPath.StartsWith(catalogFilters))
                currentFolder = activeSite.ActivePlant.PlantCatalog.Folders[0] as FilterFolder;
            else
                throw new ArgumentException("Invalid filter root specified. Should start with Plant or Catalog Filters");
            IEnumerable<string> pathEntries = filterPath.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
            Checks.IsNotNull(() => pathEntries);
            if (pathEntries.Count() == 0)
                throw new ArgumentException("Invalid filter path specified");
            int lastIndex = pathEntries.Count() - 1;            
            FilterBase filterFound = null;
            pathEntries.ForEachIndex((item, index) =>
            {
                if (index == lastIndex)
                {
                    filterFound = currentFolder.ChildFilters.FirstOrDefault(f => f.Name.Equals(item));
                    if (filterFound.Equals(default(FilterBase)))
                        throw new ArgumentException(string.Format("Filter '{0}' could not be found", item));
                }
                else
                {
                    currentFolder = currentFolder.ChildFolders.FirstOrDefault(f => f.Name.Equals(item));
                    if (currentFolder.Equals(default(FilterFolder)))
                        throw new ArgumentException(string.Format("Folder '{0}' given in filter path not found", item));
                }
            });
            return filterFound;
        }
