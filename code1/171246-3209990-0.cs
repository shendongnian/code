    /// <summary>
    /// Business Manager class for DTO object
    /// </summary>
    [DataObjectAttribute()]
    public class DTOManager
    {
        /// <summary>
        /// Function to get all DTOs records
        /// </summary>
        /// <returns>Returns List of DTOs</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static IList<DTO> GetDTOs()
        {
            return DTO_DB.GetAll();
        }
    }
