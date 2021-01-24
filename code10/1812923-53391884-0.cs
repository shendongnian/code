    public class GitHubWebHookHandler : WebHookHandler
    {
        public GitHubWebHookHandler()
        {
            this.Receiver = GitHubWebHookReceiver.ReceiverName;
        }
        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            JObject entry = context.GetDataOrDefault<JObject>();
            return Task.FromResult(true);
        }
    }
