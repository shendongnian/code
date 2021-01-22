        public string this[string property]
        {
            get {
                string msg = null;
                switch (property)
                {
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                           msg = "Need a last name";
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName))
                            msg = "Need a first name";
                        break;
                    default:
                        throw new ArgumentException(
                            "Unrecognized property: " + property);
                }
                if (msg != null && !errorCollection.ContainsKey(property))
                    errorCollection.Add(property, msg);
                if (msg == null && errorCollection.ContainsKey(property))
                    errorCollection.Remove(property);
                
                return msg;
            }
        }
        public string Error
        {
            get
            {
                if(errorCollection.Count == 0)
                    return null;
                
                StringBuilder errorList = new StringBuilder();
                var errorMessages = errorCollection.Values.GetEnumerator();
                while (errorMessages.MoveNext())
                    errorList.AppendLine(errorMessages.Current);
                return errorList.ToString();
            }
        }
