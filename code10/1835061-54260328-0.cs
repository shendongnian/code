csharp
var topic = new Topic(this, "myTopic", new TopicProps
{
    DisplayName = "myTopic",
    TopicName = "myTopic"
});
topic.AddToResourcePolicy(new PolicyStatement()
    .Describe("Default")
    .AddAwsPrincipal("*")
    .AddActions("sns:Publish",
                "sns:RemovePermission",
                "sns:SetTopicAttributes",
                "sns:DeleteTopic",
                "sns:ListSubscriptionsByTopic",
                "sns:GetTopicAttributes",
                "sns:Receive",
                "sns:AddPermission",
                "sns:Subscribe")
    .AddCondition("StringEquals", /* needs to be a map of condition key to value */);
topic.AddToResourcePolicy(new PolicyStatement()
    .Describe("ProviderBucketAllow")
    .AddAwsPrincipal("*")
    .AddAction("sns:Publish")
    .AddCondition("StringEquals", /* needs to be a map of condition key to value */);
