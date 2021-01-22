    Asset certainAsset = new Asset(32423);
    foreach (IGeneralValue dataField in certainAsset.DataFields)
    {
        object fieldValue = datafield.Value;
        Type fieldType = dataField.GetValueType();     
        if (typeof(double).Equals(fieldType))
        {
            double d = ((double)fieldValue);
        }
        else if (typeof(string).Equals(fieldType))
        {
            string d = ((string)fieldValue);
        }
        else if (typeof(whatever).Equals(fieldType))
        {
            // deal with whatever
        }
        else
        {
            // the safe option
            throw new NotSupportedException(fieldType +" is not supported!");
        }
    }
