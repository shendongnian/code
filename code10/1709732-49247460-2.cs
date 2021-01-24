	private async Task<List<HomeViewModel>> GetJobResponse(HttpResponseMessage response) {
		var result = new List<HomeViewModel>();
		if (response.IsSuccessStatusCode) {
			var jsonString = await response.Content.ReadAsStringAsync();
			try {
				result = JsonConvert.DeserializeObject<List<HomeViewModel>>(jsonString);
				if(result != null && result.Count > 0) {
					result.FirstOrDefault().isSuccess = true;
					result.FirstOrDefault().TotalJobs = result.Count();
					result.FirstOrDefault().TotalOpenJobs = result.Where(x => x.JobStatus == "Picked_Up" || x.JobStatus == "Picked Up").Count();
				}
			} catch (Exception ex) {
				var item = new HomeViewModel {
					message = ex.Message,
					isSuccess = false
				};
				result.Add(item);
			}                
			return result;
		} else {
			return null;
		}
	}
	
