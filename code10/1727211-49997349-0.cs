    public List<float> AllMyFloats
    { 
        get
        {
            var allMyFloats = new List<float>();
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(float))
                {
                    //Get the value for the property on the current instance
                    allMyFloats.Add(property.GetValue(this, null));
                }
            }
            return allMyFloats;
        }
     }
