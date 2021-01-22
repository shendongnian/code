    public bool IsValidProduct(int productTypeId)
    {
        bool isValid = false;
        if (new[] {10,11,12}.Contains(productTypeId))
        {
            isValid = true;
        }
        return isValid;
    }
