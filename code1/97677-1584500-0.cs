    From f5541188298b40515728c1ad51f645408876999c Mon Sep 17 00:00:00 2001
    From: unknown <did_bfg@.(none)>
    Date: Sun, 18 Oct 2009 12:14:26 +0200
    Subject: [PATCH] fixed namespace
    
    ---
     TaskSmart.AppLayer/UnityBootStrapper.cs |    2 +-
     1 files changed, 1 insertions(+), 1 deletions(-)
    
    diff --git a/TaskSmart.AppLayer/UnityBootStrapper.cs b/TaskSmart.AppLayer/UnityBootStrapper.cs
    index c3ed0fe..d9748a9 100644
    --- a/TaskSmart.AppLayer/UnityBootStrapper.cs
    +++ b/TaskSmart.AppLayer/UnityBootStrapper.cs
    @@ -41,7 +41,7 @@ namespace TaskSmart.AppLayer
                    {
                            unityContainer.RegisterType
                                    <
    -                                       ICommandHandler
    +                    TaskSmart.AppLayer.RequestHandlers.ICommandHandler
                                                    <
                                                            TaskSmart.AppLayer.Api.Commands.Account.CreateNewAccountCommand,
                                                            TaskSmart.AppLayer.Api.Commands.Account.CreateNewAccountResponse
    --
    1.6.4.msysgit.0
