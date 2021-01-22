    public static void ApplyPropertyChanges(this object objDest, object objToCopyFrom)
        {
            if (objDest == null)
                throw new ArgumentNullException();
            if (objToCopyFrom == null)
                throw new ArgumentNullException("objToCopyFrom");
            if (objDest.GetType() != objToCopyFrom.GetType())
                throw new Exception("Invalid type. Required: \"" + objDest.GetType().ToString() + "\"");
            foreach (System.Reflection.PropertyInfo piOrig in objDest.GetType().GetProperties())
            {
                object editedVal = objToCopyFrom.GetType().GetProperty(piOrig.Name).GetValue(objToCopyFrom, null);
                piOrig.SetValue(objDest,
                editedVal,
                null);
            }
        }
