    // Usage..
    var credentials = new AwsCredentialsFile();
    using (var client = new AmazonSQSClient(credentials, Amazon.RegionEndpoint.EUWest1))
    {
        return client.SendMessageAsync(request);
    }
    public class AwsCredentialsFile : AWSCredentials
    {
        // https://docs.aws.amazon.com/sdk-for-net/v2/developer-guide/net-dg-config-creds.html#creds-file
        private const string DefaultProfileName = "default";
        private static ConcurrentDictionary<string, ImmutableCredentials> _credentials = new ConcurrentDictionary<string, ImmutableCredentials>(StringComparer.OrdinalIgnoreCase);
        private static FileSystemWatcher _watcher = BuildFileSystemWatcher();
        private readonly System.Text.Encoding _encoding;
        private readonly string _profileName;
        public AwsCredentialsFile()
            : this(AwsCredentialsFile.DefaultProfileName, System.Text.Encoding.UTF8)
        {
        }
        public AwsCredentialsFile(string profileName)
            : this(profileName, System.Text.Encoding.UTF8)
        {
        }
        public AwsCredentialsFile(string profileName, System.Text.Encoding encoding)
        {
            _profileName = profileName;
            _encoding = encoding;
        }
        private static FileSystemWatcher BuildFileSystemWatcher()
        {
            var watcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(GetDefaultCredentialsFilePath()),
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "credentials"
            };
            watcher.Changed += (object source, FileSystemEventArgs e) => { _credentials?.Clear(); };
            watcher.EnableRaisingEvents = true;
            return watcher;
        }
        public static string GetDefaultCredentialsFilePath()
        {
            return System.Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\.aws\credentials");
        }
        public static (string AccessKey, string SecretAccessKey, string Token) ReadCredentialsFromFile(string profileName, System.Text.Encoding encoding)
        {
            var profile = $"[{profileName}]";
            string awsAccessKeyId = null;
            string awsSecretAccessKey = null;
            string token = null;
            var lines = File.ReadAllLines(GetDefaultCredentialsFilePath(), encoding);
            for (int i = 0; i < lines.Length; i++)
            {
                var text = lines[i];
                if (text.Equals(profile, StringComparison.OrdinalIgnoreCase))
                {
                    awsAccessKeyId = lines[i + 1].Replace("aws_access_key_id = ", string.Empty);
                    awsSecretAccessKey = lines[i + 2].Replace("aws_secret_access_key = ", string.Empty);
                    if (lines.Length >= i + 3)
                    {
                        token = lines[i + 3].Replace("aws_session_token = ", string.Empty);
                    }
                    break;
                }
            }
            var result = (AccessKey: awsAccessKeyId, SecretAccessKey: awsSecretAccessKey, Token: token);
            return result;
        }
        public override ImmutableCredentials GetCredentials()
        {
            if (_credentials.TryGetValue(_profileName, out ImmutableCredentials value))
            {
                return value;
            }
            else
            {
                var (AccessKey, SecretAccessKey, Token) = ReadCredentialsFromFile(_profileName, _encoding);
                var credentials = new ImmutableCredentials(AccessKey, SecretAccessKey, Token);
                _credentials.TryAdd(_profileName, credentials);
                return credentials;
            }
        }
    }
