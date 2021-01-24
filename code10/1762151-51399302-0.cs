    public class PersonConverter : Converter
    {
        private Dictionary<int, int> _IDs;
    
        public PersonConverter()
        {
            this._IDs = new Dictionary<int, int>();
        }
    
        public int Convert(int oldPersonID)
        {
            int newPersonID = int.MinValue;
            if (this._IDs.TryGetValue(oldPersonID, out newPersonID))
            {
                /* This oldPerson has been looked up before.
                 * The TryGetValue is fast so just let's do that and return the newPersonID */
                return newPersonID;
            }
            else
            {
                try
                {
                    /* This oldPerson has NOT been looked up before 
                    * so we need to retrieve it from out source and update
                    * the dictionary */
                    int newPersonID = GetNewPersonIDForPerson(oldPersonID);
                    this._IDs.Add(oldPersonID, newPersonID);
                    return newPersonID;
                }
                catch (SourceKeyNotFoundException)
                {
                    throw;
                }   
            }
        }
    }
