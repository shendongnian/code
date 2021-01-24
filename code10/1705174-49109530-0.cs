    private List<GetStatus> DownloadLatestFiles()
        {
            Workspace workspace = null;
            List<GetStatus> statusResult = new List<GetStatus>();
            try
            {
                workspace = SetupWorkSpace();
                List<Solution> services = _serviceList.GetAll();
               foreach (Solution solution in services)
                {
                    WorkingFolder workingFolder = new WorkingFolder(ConvertLocalToTfsPath(solution), GetSolutionFolder(solution));
                    workspace.CreateMapping(workingFolder);
                    GetRequest request = new GetRequest(new ItemSpec(ConvertLocalToTfsPath(solution), RecursionType.Full), VersionSpec.Latest);
                    statusResult.Add(workspace.Get(request, GetOptions.GetAll | GetOptions.Overwrite));
                }
            }
            catch
            {
                throw;
            }
            return statusResult;
        }
