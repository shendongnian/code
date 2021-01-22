        static Type GetCommonBaseClass(Type[] types)
        {
            if (types.Length == 0)
                return (typeof(object));
            else if (types.Length == 1)
                return (types[0]);
            // Copy the parameter so we can substitute base class types in the array without messing up the caller
            Type[] temp = new Type[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
                temp[i] = types[i];
            }
            bool checkPass = false;
            Type tested = null;
            while (!checkPass)
            {
                tested = temp[0];
                checkPass = true;
                for (int i = 1; i < temp.Length; i++)
                {
                    if (tested.Equals(temp[i]))
                        continue;
                    else
                    {
                        // If the tested common basetype (current) is the indexed type's base type
                        // then we can continue with the test by making the indexed type to be its base type
                        if (tested.Equals(temp[i].BaseType))
                        {
                            temp[i] = temp[i].BaseType;
                            continue;
                        }
                        // If the tested type is the indexed type's base type, then we need to change all indexed types
                        // before the current type (which are all identical) to be that base type and restart this loop
                        else if (tested.BaseType.Equals(temp[i]))
                        {
                            for (int j = 0; j <= i - 1; j++)
                            {
                                temp[j] = temp[j].BaseType;
                            }
                            checkPass = false;
                            break;
                        }
                        // The indexed type and the tested type are not related
                        // So make everything from index 0 up to and including the current indexed type to be their base type
                        // because the common base type must be further back
                        else
                        {
                            for (int j = 0; j <= i; j++)
                            {
                                temp[j] = temp[j].BaseType;
                            }
                            checkPass = false;
                            break;
                        }
                    }
                }
                // If execution has reached here and checkPass is true, we have found our common base type, 
                // if checkPass is false, the process starts over with the modified types
            }
            // There's always at least object
            return tested;
        }
