            Guid newGuid = Guid.NewGuid();
            var classA = new ClassA{Id = newGuid};
            var classB = new ClassB{Id = newGuid};
            PropertyInfo[] classAProperties = classA.GetType().GetProperties();
            Dictionary<string, object> classAPropertyValue = classAProperties.ToDictionary(pName => pName.Name,
                                                                                    pValue =>
                                                                                    pValue.GetValue(classA, null));
            PropertyInfo[] classBProperties = classB.GetType().GetProperties();
            Dictionary<string, object> classBPropetyValue = classBProperties.ToDictionary(pName => pName.Name,
                                                                                    pValue =>
                                                                                    pValue.GetValue(classB, null));
    internal class ClassB
    {
        public Guid Id { get; set; }
    }
    internal class ClassA
    {
        public Guid Id { get; set; }
    }
    classAPropertyValue
    Count = 1
        [0]: {[Id, d0093d33-a59b-4537-bde9-67db324cf7f6]}
    
    classBPropetyValue
    Count = 1
        [0]: {[Id, d0093d33-a59b-4537-bde9-67db324cf7f6]}
