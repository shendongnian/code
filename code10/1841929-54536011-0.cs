                if (value.IsSubclassOf(typeof(ClassBase)))
                {
                    _typeOfClassBase = value.GetType();
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(TypeOfClassBase)} must be a subclass of {nameof(ClassBase)}");
                }
