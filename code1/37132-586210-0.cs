    // Rename 'query' to something meaningful :)
    var query = _fixture.Images
                        .Where(image => _selectedFixtureImage.Filename 
                                        && image.IsPrimary);
    foreach (FixtureImageServicesData image in query)
    {
        image.IsPrimary = false;
        image.IsChanged = true;
    }
