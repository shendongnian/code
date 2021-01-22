    /* In model class */
    public void Validate(string dealerId)
    {
        ExceptionList exceptions = new ExceptionList();
        if (String.IsNullOrEmpty(this.UserName))
        {
            exceptions.Exceptions.Add(new InvalidFieldException("Error message", "ContractType"));
        }
        ... other validations ...
        if (exceptions.Exceptions.Count > 0)
        {
            throw exceptions;
        }
    }
    /* In controller */
    public virtual ActionResult UpdateProfile(User user)
    {
        try
        {
            user.Validate();
        }
        catch (ExceptionList ex)
        {
            ex.CopyToModelState(ModelState);
        }
    }
    /* Custom types (ExceptionList / InvalidFieldException) */
 
    [Serializable]
    public class ExceptionList : Exception
    {
        private List<Exception> exceptions;
        public List<Exception> Exceptions
        {
            get { return exceptions; }
            set { exceptions = value; }
        }
        public ExceptionList() { Init(); }
        public ExceptionList(string message) : base(message) { Init(); }
        public ExceptionList(string message,
            System.Exception inner)
            : base(message, inner) { Init(); }
        protected ExceptionList(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { Init(); }
        private void Init()
        {
            Exceptions = new List<Exception>();
        }
    }
    [Serializable]
    public class InvalidFieldException : Exception
    {
        private string fieldName;
        public string FieldName
        {
            get
            {
                return fieldName;
            }
            set
            {
                fieldName = value;
            }
        }
        private string fieldId;
        public string FieldId
        {
            get
            {
                return fieldId;
            }
            set
            {
                fieldId = value;
            }
        }
        public InvalidFieldException() { }
        public InvalidFieldException(string message) : base(message) { }
        public InvalidFieldException(string message, string fieldName)
            : base(message)
        {
            this.fieldName = fieldName;
        }
        public InvalidFieldException(string message, string fieldName, string fieldId)
            : base(message)
        {
            this.fieldName = fieldName;
            this.fieldId = fieldId;
        }
        public InvalidFieldException(string message, System.Exception inner)
            : base(message, inner) { }
        public InvalidFieldException(string message, string fieldName,
            System.Exception inner)
            : base(message, inner)
        {
            this.fieldName = fieldName;
        }
        public InvalidFieldException(string message, string fieldName, string fieldId,
             System.Exception inner)
            : base(message, inner)
        {
            this.fieldName = fieldName;
            this.fieldId = fieldId;
        }
        protected InvalidFieldException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
    /* Extension method (to copy ExceptionList exceptions to ModelState) */
    /// <summary>
    /// Copies an ExceptionList to ModelState for MVC
    /// </summary>
    /// <param name="exList">List of exceptions</param>
    /// <param name="modelState">Model state to populate</param>
    /// <param name="collection">Form collection of data posted to the action</param>
    /// <param name="prefix">Prefix used in view (if any)</param>
    /// <param name="isCollection">Indicates whether a collection of objects are being returned from the view (requires prefix)</param>
    [CLSCompliant(false)]
    public static void CopyToModelState(this ExceptionList exList, ModelStateDictionary modelState, FormCollection collection, string prefix, bool isCollection)
    {
        foreach (InvalidFieldException ex in exList.Exceptions)
            if (String.IsNullOrEmpty(prefix))
            {
                modelState.AddModelError(ex.FieldName, ex.Message);
                modelState.SetModelValue(ex.FieldName, collection.ToValueProvider()[ex.FieldName]);
            }
            else
            {
                if (isCollection)
                {
                    modelState.AddModelError(prefix + "[" + ex.FieldId + "]." + ex.FieldName, ex.Message);
                    modelState.SetModelValue(prefix + "[" + ex.FieldId + "]." + ex.FieldName, collection.ToValueProvider()[ex.FieldName]);
                }
                else
                {
                    modelState.AddModelError(prefix + "." + ex.FieldName, ex.Message);
                    modelState.SetModelValue(prefix + "." + ex.FieldName, collection.ToValueProvider()[ex.FieldName]);
                }
            }
    }
        /// <summary>
        /// Copies an ExceptionList to ModelState for MVC
        /// </summary>
        /// <param name="exList">List of exceptions</param>
        /// <param name="modelState">Model state to populate</param>
        [CLSCompliant(false)]
        public static void CopyToModelState(this ExceptionList exList, ModelStateDictionary modelState)
        {
            CopyToModelState(exList, modelState, null, false);
        }
        /// <summary>
        /// Copies an ExceptionList to ModelState for MVC
        /// </summary>
        /// <param name="exList">List of exceptions</param>
        /// <param name="modelState">Model state to populate</param>
        /// <param name="collection">Form collection of data posted to the action</param>
        [CLSCompliant(false)]
        public static void CopyToModelState(this ExceptionList exList, ModelStateDictionary modelState, FormCollection collection)
        {
            CopyToModelState(exList, modelState, collection, null, false);
        }
