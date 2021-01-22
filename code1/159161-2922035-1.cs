    public List<CheckBox> GetMyCheckBoxes(userID)
    {        
        IDictionary<int, bool> selectedModels = new Dictionary<int, bool>();
        ModelRespository modelRespository = new ModelRespository();
        
        foreach (var model in modelRespository.GetUserSelectedModels(userID))
        {
            selectedModels.Add(model.ModelID);
        }
        return (from m in modelRespository.GetModels()
            select new CheckBox
            {
                ID = m.ModelID.ToString(),
                Text = m.Name,
                Checked = selectedModels.ContainsKey(m.ID)
            }).ToList();
    }
