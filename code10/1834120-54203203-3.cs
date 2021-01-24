    public void Serialization()
    {
        var dto = JsonConvert.DeserializeObject<Demo>(json);                       
        var postData = JsonConvert.SerializeObject(dto.Variables);
    }
