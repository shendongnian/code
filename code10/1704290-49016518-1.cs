    static void Main(string[] args)
    {
        RiskService riskService = new RiskService();
        var result = riskService.GetRisks().FirstOrDefault(x => x.Id == 8);
        Console.WriteLine(result?.Owner.Name);
    }
