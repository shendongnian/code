    class Chandelier : Lamp
    {
        public new string GetSize()
        {
            var baseSize = base.GetSize();
            return baseSize.Split('x')[1].Trim();  // Only show the length
        }
    }
