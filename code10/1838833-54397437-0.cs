    class LabelsDTO
    {
        public Labels[] Labels{get;set;}
    }
    ...
    var dto = JsonConvert.DeserializeObject<LabelsDTO>(sub);
    for (var label in dto.Labels)
    {
    ...
    }
    
