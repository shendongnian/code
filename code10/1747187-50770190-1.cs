    public async Task<IActionResult> ValidateSiteCodes(SiteCodeInputsViewModel siteCodeInputs) {
        if (ModelState.IsValid) {
            var values = new Dictionary<string, string> {
                {"sourceSiteCode", siteCodeInputs.SourceSiteCode.Sitecode},
                {"targetSiteCode", siteCodeInputs.TargetSiteCode.Sitecode}
            };
            var content = new FormUrlEncodedContent(values);
            var clientTransferValoidateSiteCodesApiUrl = $"api/wcfctu/validatesitecodes";
            HttpResponseMessage response = await _httpHelper.PostAsync(clientTransferValoidateSiteCodesApiUrl, content);
            if (response.IsSuccessStatusCode) {
                var jsonData = await response.Content.ReadAsStringAsync();
                return Ok(jsonData);
            }
        }
        return BadRequest(ModelState);
    }
    
