    public class AWSCloudFormation
    {
        public string StackName { get; set; }
        public string TemplateUrl { get; set; }
        AmazonCloudFormationClient CloudFormationClient;
        public AWSCloudFormation(string stackName, string templateUrl)
        {
            CloudFormationClient = CreateCloudFormationClient();
            StackName = stackName;
            TemplateUrl = templateUrl;
        }
        public AmazonCloudFormationClient CreateCloudFormationClient()
        {
            var amazonCloudFormationConfig = new AmazonCloudFormationConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(Program.AWSLambdaToolsJsonConfig.Region),
            };
            return new AmazonCloudFormationClient(Program.AccessKey, Program.SecretKey, amazonCloudFormationConfig);
        }
        static Stack GetStack(AmazonCloudFormationClient cloudFormationClient, string name)
        {
            return cloudFormationClient.DescribeStacks(new DescribeStacksRequest { StackName = name }).Stacks.First();
        }
        public void CreateCloudFormationOnAWS()
        {
            try
            {
                Log.Info(Program.LogPath, "Creating Cloud Information");
                var describeStacksRequest = new DescribeStacksRequest();
                var changeSetName = "changeset" + Program.PostfixExpression;
                var changeSetType = ChangeSetType.CREATE;
                if (CheckStackIsExist(CloudFormationClient, StackName))
                {
                    changeSetType = ChangeSetType.UPDATE;
                }
                var createChangeSetRequest = new CreateChangeSetRequest
                {
                    ChangeSetName = changeSetName,
                    StackName = StackName,
                    //TemplateBody = ServerlessTemplateBody,
                    TemplateURL = TemplateUrl,
                    ChangeSetType = changeSetType,
                    Capabilities = new List<string> { "CAPABILITY_IAM" },
                };
                var createChangeSetResponse = CloudFormationClient.CreateChangeSet(createChangeSetRequest);
                WaitForChangeSet(CloudFormationClient, StackName, changeSetName);
                var executeChangeSetResponse = CloudFormationClient.ExecuteChangeSet(new ExecuteChangeSetRequest
                {
                    ChangeSetName = changeSetName,
                    StackName = StackName,
                });
                WaitForStack(CloudFormationClient, StackName);
                var generatedStack = GetStack(CloudFormationClient, StackName);
                Log.Info(Program.LogPath, "Output URL is : " + generatedStack.Outputs.Find(x => x.OutputKey == "ApiURL").OutputValue);
                Log.Info(Program.LogPath, "Creating Cloud Information Finished");
            }
            catch (Exception ex)
            {
                Log.Error(Program.LogPath.FullName, "Creating Cloud Information  Error :   " + ex.Message);
            }
        }
        static void WaitForChangeSet(AmazonCloudFormationClient amazonCloudFormationClient, string stackName, string changeSetName)
        {
            var status = ChangeSetStatus.CREATE_PENDING;
            while (status != ChangeSetStatus.CREATE_COMPLETE)
            {
                var changeSet = amazonCloudFormationClient.DescribeChangeSet(new DescribeChangeSetRequest { StackName = stackName, ChangeSetName = changeSetName });
                status = changeSet.Status;
                Log.Info(Program.LogPath, $"Changeset '{changeSetName}' (In Stack : {stackName}) status is {changeSet.Status}  at {DateTime.Now.TimeOfDay}");
                if (status != ChangeSetStatus.CREATE_COMPLETE) Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
        static void WaitForStack(AmazonCloudFormationClient amazonCloudFormationClient, string stackName)
        {
            var stack = GetStack(amazonCloudFormationClient, stackName);
            var status = stack.StackStatus;
            string statusReason = null;
            while (status == StackStatus.CREATE_IN_PROGRESS ||
                    status == StackStatus.UPDATE_IN_PROGRESS ||
                    status == StackStatus.UPDATE_ROLLBACK_IN_PROGRESS ||
                    status == StackStatus.ROLLBACK_IN_PROGRESS ||
                    status == StackStatus.UPDATE_ROLLBACK_COMPLETE_CLEANUP_IN_PROGRESS ||
                    status == StackStatus.UPDATE_COMPLETE_CLEANUP_IN_PROGRESS ||
                    status == StackStatus.REVIEW_IN_PROGRESS)
            {
                
                stack = GetStack(amazonCloudFormationClient, stackName);
                status = stack.StackStatus;
                statusReason = stack.StackStatusReason;
                Log.Info(Program.LogPath, $"Stack '{stackName}' status is {status} because {statusReason} at {DateTime.Now.TimeOfDay}");
                if (status == StackStatus.CREATE_IN_PROGRESS || status == StackStatus.UPDATE_IN_PROGRESS) Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            if (status != StackStatus.CREATE_COMPLETE &&
                status != StackStatus.UPDATE_COMPLETE &&
                status != StackStatus.ROLLBACK_COMPLETE &&
                status != StackStatus.UPDATE_ROLLBACK_COMPLETE)
            {
                var eventsResponse = amazonCloudFormationClient.DescribeStackEvents(new DescribeStackEventsRequest { StackName = stackName });
                throw new FailedToCreateStackException(stackName, RegionEndpoint.GetBySystemName(Program.AWSLambdaToolsJsonConfig.Region), status.Value, statusReason, eventsResponse.StackEvents);
            }
        }
        static bool CheckStackIsExist(AmazonCloudFormationClient amazonCloudFormationClient, string stackName)
        {
            try
            {
                var stack =
                amazonCloudFormationClient.DescribeStacks(new DescribeStacksRequest { StackName = stackName }).Stacks.First();
                if (stack != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
