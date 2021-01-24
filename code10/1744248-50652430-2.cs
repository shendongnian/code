    public class Repair
    {
        public bool Active { get; set; }
        public Action<MechDef> Update { get; set; }
    }
    public class Settings 
    {
        public readonly Dictionary<string, Repair> LimbRepair = 
            new Dictionary<string, bool> {
            { 
                "Head", 
                new Repair { Active = false, mechDef => mechDef.Head.CurrentInternalStructure = yourFunctionForHead }
            },
            { 
                "LeftArm", 
                new Repair { Active = false, mechDef => mechDef.LeftArm.CurrentInternalStructure = yourFunctionForLeftArm }
            },
            // ... and so on
        };
    }
