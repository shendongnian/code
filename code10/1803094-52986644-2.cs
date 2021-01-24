    public int MobileExistToAnotherGenerationUnit(string mobileNo, long generationUnitId)
    {
        int result = _mobileRepository.Table
        .Where(gum => gum.mobileno == mobileNo && gum.generation_unit_id != 
         generationUnitId)
        .Select(s => new Generation_unit_mobile
        {
            id = s.id
        }).ToList().Count;
        return result == 0 ? 0 : 1;
    }
