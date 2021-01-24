C#
public async Task<myModel[]> GetlistOfDstAsync()
{
  var req = new RequestGenerator();
  var InitializedObjects = req.GetInitializedObjects();
  var tasks = InitializedObject.Select(async item =>
  {
    RestRequest request = new RestRequest("resource",Method.GET);
    request.AddQueryParameter("key", item.valueOne);
    request.AddQueryParameter("key", item.valueTwo);
    return await GetAsync<myModel>(request);
  }).ToList();
  var results = await TaskWhenAll(tasks);
  return results;
}
