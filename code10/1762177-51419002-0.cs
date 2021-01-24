    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SimulationVariableModel
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public readonly string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public readonly string Category;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public readonly string Id;
        public SimulationVariableModel(string name, string category, string objectId)
        {
            Name = name;
            Category = category;
            Id = objectId;
        }
    }
