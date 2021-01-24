            var troposLogs = new TroposLog[]
            {
                new TroposLog
                {
                    Created = DateTime.Now, 
                    UserName = null,
                    SessionId = "4d50b064-d269-4256-a187-82a3f9402735",
                    ActionName = null,
                    Message = "Client successfully got the transaction result"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = null,
                    SessionId = "4d50b064-d269-4256-a187-82a3f9402735",
                    ActionName = "SOCS",
                    Message = "Run Transaction Requested (SOCS)... Success"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = "DAIW",
                    SessionId = "c0c2311a-b509-4e6e-a236-80e2d86f2647",
                    ActionName = null,
                    Message = "New Session Requested... Success (Start Session Thread Started)"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = null,
                    SessionId = "4d50b064-d269-4256-a187-82a3f9402735",
                    ActionName = "SOCS",
                    Message = "Run Transaction Thread (SOCS)... Success"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = null,
                    SessionId = "4d50b064-d269-4256-a187-82a3f9402735",
                    ActionName = null,
                    Message = "Client successfully got the transaction result"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = "DAIW",
                    SessionId = "c0c2311a-b509-4e6e-a236-80e2d86f2647",
                    ActionName = null,
                    Message = "Start Session ThreadSuccess (c0c2311a-b509-4e6e-a236-80e2d86f2647)"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = null,
                    SessionId = "c0c2311a-b509-4e6e-a236-80e2d86f2647",
                    ActionName = null,
                    Message = "Client Successfully Retrieved Session"
                },
                new TroposLog
                {
                    Created = DateTime.Now,
                    UserName = null,
                    SessionId = "4d50b064-d269-4256-a187-82a3f9402735",
                    ActionName = "",
                    Message = "End Session Requested - Thread started"
                },
            };
            var orderedLogs = troposLogs.OrderBy(l => l.Created) // Just in case
                                        .GroupBy(l => l.SessionId)
                                        .OrderBy(g => g.FirstOrDefault().Created)
                                        .SelectMany(g => g)
                                        .ToList();
