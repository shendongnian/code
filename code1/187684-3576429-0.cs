            serviceHost.Open();
            // Iterate through the endpoints contained in the ServiceDescription 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(string.Format("Active Service Endpoints:{0}", Environment.NewLine), 128);
            foreach (ServiceEndpoint se in serviceHost.Description.Endpoints)
            {
                sb.Append(String.Format("Endpoint:{0}", Environment.NewLine));
                sb.Append(String.Format("\tAddress: {0}{1}", se.Address, Environment.NewLine));
                sb.Append(String.Format("\tBinding: {0}{1}", se.Binding, Environment.NewLine));
                sb.Append(String.Format("\tContract: {0}{1}", se.Contract.Name, Environment.NewLine));
                foreach (IEndpointBehavior behavior in se.Behaviors)
                {
                    sb.Append(String.Format("Behavior: {0}{1}", behavior, Environment.NewLine));
                }
            }
            Console.WriteLine(sb.ToString());
