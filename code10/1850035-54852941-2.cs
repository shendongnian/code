    [Route("{country}")]
    public IActionResult CountryPage(string country)
    {
        return Ok(country);
    }
