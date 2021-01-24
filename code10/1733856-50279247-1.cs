    public IActionResult Create()
    {
        var vm = new CreateStationViewModel
        {
            // Construct a list of available states.
            // We will use it as the dropdown options.
            AvailableStates = _context.States
                .ToDictionary(x => x.Id, x => $"{ x.Name }({ x.Code })")
        };
        return View(vm);
    }
