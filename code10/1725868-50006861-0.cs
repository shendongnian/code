    int debugId = 0;
    try
    {
        ReviewNote rn = new ReviewNote(); // debugId == 0
        ++debugId;
        rn.auditID = ra.Id; // debugId == 1
        ++debugId;
        rn.Type = (int)this.LoggedInUser.ReviewTypeId; // debugId == 2
        ++debugId;
        MapViewModelToModel(rn, viewModel); // debugId == 3
        ++debugId;
        _repository.Save<ReviewNote>(rn); // debugId == 4
    }
    catch (NullReferenceException nre)
    {
        throw new Exception("debugId:" + debugId, nre);
    }
