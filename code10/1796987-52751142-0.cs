    public async Task<IActionResult> AddStudiosToMovie(int  movieID, List<int> studioIdList)
        {
           for(int i=0;i<studioIdList.Count();i++)
            {
                var movieToStudio = new MovieStudios
                {
                    MovieID = movieID,
                    StudioID = studioIdList[i]
                };
                _context.Add(movieToStudio);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
            
        }
