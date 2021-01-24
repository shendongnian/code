    class Program
    {
        static async Task Main(string[] args)
        {
            // ...
            using (var workspace = MSBuildWorkspace.Create())
            {
                var solutionPath = args[0];
                WriteLine($"Loading solution '{solutionPath}'");
                var solution = await workspace.OpenSolutionAsync(solutionPath,
                        new ConsoleProgressReporter());
                WriteLine($"Finished loading solution '{solutionPath}'");
                // insert your code here
            }
        }
        private static VisualStudioInstance SelectVisualStudioInstance(
            VisualStudioInstance[] visualStudioInstances)
        {
            // ...
        }
        private class ConsoleProgressReporter : IProgress<ProjectLoadProgress>
        {
            // ...
        }
    }
