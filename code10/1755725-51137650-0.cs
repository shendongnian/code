    private void UpdateGeneralData(object Entity, Dictionary<Type,List<HierarchyLevel>> TypeData)
    {
        CBType.Items.Clear();
        foreach (var item in TypeData[Entity.GetType()])
        {
            CBType.Items.Add(item);
        }
    }
