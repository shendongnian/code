            foreach (var clusterManager in clusterManagers)
            {
                var clusterName = clusterManager.Name;
                string opcDataSourceServer = "server/" + clusterName + ":[2:http://www.alstom.com/Transport/Iconis/S2K/Data]<Organizes>2:S2KServer<Organizes>2:S2KTerritoryMngt<Organizes>2:TASSObject<HasComponent>2:OperatorAudibleSev";
                var opcVariable = m_alsApplication.Database.GetVariable(opcDataSourceServer, null);
                opcVariable.YourEvent += OpcVariable_YourEvent;
                m_operatorAudibleSevServerVariables.Add(clusterManager.Name, opcVariable);                
            }
