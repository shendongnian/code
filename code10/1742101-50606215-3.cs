    public static class GitHttpClientExt
    {
        /// <summary>
        /// Gets a value indicating whether a branch with name <paramref name="branch"/> (like 'master', 'dev') contains the commit with specified <paramref name="commitId"/>.
        /// Just like the <code>git branch --contains</code> it doesn't take possible reversions into account.
        /// </summary>
        public static Boolean BranchContains(this GitHttpClient git, String project, String repositoryId, String branch, String commitId)
        {
            var commitToFind = git.TryGetCommit(project: project, repositoryId: repositoryId, commitId: commitId);
            if (commitToFind == null)
            {
                return false;
            }
            var committedDate = commitToFind.Committer.Date; // TODO: It will usually be the same as the author's, but I have failed to check what date TFS actually uses in date queries.
            var criteria = new GitQueryCommitsCriteria
            {
                ItemVersion = new GitVersionDescriptor
                {
                    Version = branch,
                    VersionType = GitVersionType.Branch
                },
                FromDate = DateToString(committedDate.AddSeconds(-1)), // Zero length interval seems to work, but just in case
                ToDate = DateToString(committedDate.AddSeconds(1)),
            };
            var commitIds = git
                .GetAllCommits(
                    project: project, 
                    repositoryId: repositoryId,
                    searchCriteria: criteria)
                .Select(c => c.CommitId)
                .ToHashSet(StringComparer.InvariantCultureIgnoreCase);
            return commitIds.Contains(commitId);
        }
        /// <summary>
        /// Gets the string representation of <paramref name="dateTime"/> usable in query objects for <see cref="GitHttpClient"/>.
        /// </summary>
        public static String DateToString(DateTimeOffset dateTime)
        {
            return dateTime.ToString(CultureInfo.InvariantCulture);
        }
        /// <summary>Tries to retrieve git commit with specified <paramref name="commitId"/> for a project.</summary>
        public static GitCommitRef TryGetCommit(this GitHttpClient git, String project, String repositoryId, String commitId)
        {
            return git
                .GetAllCommits(
                    project: project,
                    repositoryId: repositoryId,
                    searchCriteria: new GitQueryCommitsCriteria
                    {
                        Ids = new List<String>
                        {
                            commitId
                        }
                    })
                .SingleOrDefault();
        }
        /// <summary>Retrieve all(up to <see cref="Int32.MaxValue"/>) git (unless <paramref name="top"/> is set) commits for a project</summary>
        public static List<GitCommitRef> GetAllCommits(
            this GitHttpClient git, 
            String project,
            String repositoryId, 
            GitQueryCommitsCriteria searchCriteria, 
            Int32? skip = null, 
            Int32? top = (Int32.MaxValue - 1)) // Current API somehow fails (silently!) on Int32.MaxValue;
        {
            return git
                .GetCommitsAsync(
                    project: project,
                    repositoryId: repositoryId,
                    searchCriteria: searchCriteria,
                    skip: skip,
                    top: top)
                .GetAwaiter()
                .GetResult();
        }
    }
