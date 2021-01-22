    Hashtable htImageTypes = new Hashtable();
    htImageTypes.Add("JPEG", "*.jpg");
    htImageTypes.Add("GIF", "*.gif");
    htImageTypes.Add("BMP", "*.bmp");
    
    foreach (DictionaryEntry ImageType in htImageTypes)
    {
    	cmbImageType.Items.Add(ImageType);
    }
    cmbImageType.DisplayMember = "key";
    cmbImageType.ValueMember = "value";
