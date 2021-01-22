            // Create unity container my service and repository
            ISecurityRepository securityRepository = new SecurityRepository();
            ISecurityService securityService = new SecurityService(securityRepository);
            
            container = new UnityContainer();
            container.RegisterInstance<ISecurityRepository>(securityRepository);
            container.RegisterInstance<ISecurityService>(securityService);
