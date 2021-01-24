    var newViewModel = new List<JournalDetails>();
    foreach (var item in newViewModel.JournalDetailsViewModel)
    {
        if (item != null)
        {
            ...
            newViewModel.Add(item);
        }
    }
    var dtails = _mapper.Map<List<JournalDetails>>(newViewModel.JournalDetailsViewModel);
    _context.AddRange(newViewModel);
    ...
