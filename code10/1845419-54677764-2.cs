    [Route("/vars"]
    public class GetVariables : IReturn<GetVariablesResponse>
    {
        public string Symbols { get; set; }
    }
