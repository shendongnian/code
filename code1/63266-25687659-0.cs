                // Checks to see if the value passed is valid. 
                if (!TypeDescriptor.GetConverter(typeof(T)).IsValid(value))
                {
                    throw new ArgumentException();
                }
