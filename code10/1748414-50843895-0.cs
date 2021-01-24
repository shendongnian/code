    public class DockerStarter : IDisposable
    {
        private const string DOCKER_COMPOSE = @"c:\Program Files\Docker\Docker\resources\bin\docker-compose.exe";
        public string ComposeFile { get; set; }
        public string WorkingDir { get; set; }
        public DockerStarter(string composeFile, string workingDir)
        {
            ComposeFile = composeFile;
            WorkingDir = workingDir;
        }
        public void Start()
        {
            var startInfo = generateInfo("up");
            _dockerProcess = Process.Start(startInfo);
            // TODO: Find better way to wait for Docker containers to start
            Thread.Sleep(1000);
        }
        private Process _dockerProcess;
        public void Dispose()
        {
            _dockerProcess.Close();
            var stopInfo = generateInfo("down");
            var stop = Process.Start(stopInfo);
            stop.WaitForExit();
        }
        private ProcessStartInfo generateInfo(string argument)
        {
            var procInfo = new ProcessStartInfo
            {
                FileName = DOCKER_COMPOSE,
                Arguments = $"-f {ComposeFile} {argument}",
                WorkingDirectory = WorkingDir
            };
            return procInfo;
        }
    }
