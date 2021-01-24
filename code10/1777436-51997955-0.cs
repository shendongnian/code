        public class Command : IRequest<AcceptCostEstimateResponse>
        {
            public Command()
           {
               Estimate = new EstimateDTO();
               ClientHeader = new ClientHeaderDTO();
            }
            public EstimateDTO Estimate { get; set; }
            public ClientHeaderDTO ClientHeader { get; set; }
        }
