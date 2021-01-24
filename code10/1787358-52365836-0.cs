    public async Task<IActionResult> Get(string id)
    {
        var model = await _recommendationRepository.GetRecommendation(id);
        return View("RecommendationDetails", model);
    }
