    public async Task<WorkItemAtrr> UpdatedWorkItem(int pId, Dictionary<String, String> pFields)
    {
    	//PATCH https://{instance}/DefaultCollection/_apis/wit/workitems/{id}?api-version={version}
        string _query_url = String.Format("https://YOUR_SERVER/DefaultCollection/_apis/wit/workitems/{id}?api-version=1.0", pId);
        List<Object> flds = new List<Object>();
        foreach (var _key in pFields.Keys)
            flds.Add(new NewField { op = "add", path = "/fields/" + _key, value = pFields[_key] });
        HttpResponseMessage _response = await DoRequest(_query_url, JsonConvert.SerializeObject(flds), ClientMethod.PATCH);
        return JsonConvert.DeserializeObject<WorkItemAtrr>(await ProcessResponse(_response));
    }
