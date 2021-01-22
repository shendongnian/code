    static void RegisterHandlers_Account(IUnityContainer unityContainer)
    		{
    			unityContainer.RegisterType
    				<
                        TaskSmart.AppLayer.RequestHandlers.ICommandHandler
    						<
    							TaskSmart.AppLayer.Api.Commands.Account.CreateNewAccountCommand,
    							TaskSmart.AppLayer.Api.Commands.Account.CreateNewAccountResponse
    						>,
    					TaskSmart.AppLayer.RequestHandlers.Account.CreateNewAccountHandler
    				>(new TransientLifetimeManager());
    		}
