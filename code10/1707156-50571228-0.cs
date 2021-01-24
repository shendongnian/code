    [HttpGet]
    public async Task < IActionResult > Get() 
    {
     if (!ModelState.IsValid) return BadRequest(ModelState);
     var movies = await MovieService.GetMovies();
     return Ok(movies);
    }
