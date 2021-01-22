        public struct RollInformationCSharp
        {
            [MarshalAs(UnmanagedType.R8)]
            public double rollDiameter;
            public double initialRoughness;
            public double finalRoughness;
            public double accumulateCombination;
            public double critialRollLength;
            public double rolledLength;
            public double percentageLifeRoll;
    
            [MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 256)]
            public string rollName;
        };
       [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class MultiRollCSharp
        {
            [MarshalAs(UnmanagedType.I4)]
            public int nbRoll;
    
            public RollInformationCSharp[] tabRoll;
        }
