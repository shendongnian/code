    var champions = _context.Champions.Select(x => new
    {
       x.Name,
       x.Surname,
    }).ToList();
    List<Models.ViewModel.Champion> cham = new List<Models.ViewModel.Champion>();
    foreach (var iteam in champions)
    {
       cham.Add(new Models.ViewModel.Champion { Name = iteam.Name, Surname= iteam.Surname });
    }
    return View(cham);
