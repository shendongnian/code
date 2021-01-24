    private void UpdateList(ModelObj modelObj)
    {
        var testObj = ModelObjects.FirstOrDefault(x => x.Name == modelObj.Name);
        if (testObj != null)
        {
            testObj.Timer = modelObj.Timer
        }
        else
        {
            ModelObjects.Add(modelObj);
        }
    }
