    internal interface ILuisResult
    {
        string Query { get; }
    }
    internal class LuisResultAdapter : ILuisResult
    {
        private readonly LuisResult _luisResult;
        public LuisResultAdapter(LuisResult luisResult)
        {
            _luisResult = luisResult;
        }
        public string Query => _luisResult.Query;
    }
