    public unsafe class JsonReplace : Benchmark<string, Dictionary<string,int>>
    {
       protected override Dictionary<string,int> InternalRun()
       {
         return JsonConvert.DeserializeObject<Dictionary<string,int>>(Input.Replace("=", ":"));
       }
    }
