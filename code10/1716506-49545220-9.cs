    class Lamp : Decor
    {
    }
    class Rug : Decor
    {
        public new string GetSize()
        {
            var baseSize = base.GetSize();
            var lastX = baseSize.LastIndexOf("x");
            return baseSize.Substring(0, lastX - 1).Trim();  // Only show Width and Length
        }
    }
