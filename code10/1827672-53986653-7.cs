     private static void ValidateDefaultValueCommon(
            object defaultValue,
            Type propertyType,
            string propertyName,
            ValidateValueCallback validateValueCallback,
            bool checkThreadAffinity)
        {
            // Ensure default value is the correct type
            if (!IsValidType(defaultValue, propertyType))
            {
                throw new ArgumentException(SR.Get(SRID.DefaultValuePropertyTypeMismatch, propertyName));
            }
 
            // An Expression used as default value won't behave as expected since
            //  it doesn't get evaluated.  We explicitly fail it here.
            if (defaultValue is Expression )
            {
                throw new ArgumentException(SR.Get(SRID.DefaultValueMayNotBeExpression));
            }
 
            if (checkThreadAffinity)
            {
                // If the default value is a DispatcherObject with thread affinity
                // we cannot accept it as a default value. If it implements ISealable
                // we attempt to seal it; if not we throw  an exception. Types not
                // deriving from DispatcherObject are allowed - it is up to the user to
                // make any custom types free-threaded.
 
                DispatcherObject dispatcherObject = defaultValue as DispatcherObject;
 
                if (dispatcherObject != null && dispatcherObject.Dispatcher != null)
                {
                    // Try to make the DispatcherObject free-threaded if it's an
                    // ISealable.
 
                    ISealable valueAsISealable = dispatcherObject as ISealable;
 
                    if (valueAsISealable != null && valueAsISealable.CanSeal)
                    {
                        Invariant.Assert (!valueAsISealable.IsSealed,
                               "A Sealed ISealable must not have dispatcher affinity");
 
                        valueAsISealable.Seal();
 
                        Invariant.Assert(dispatcherObject.Dispatcher == null,
                            "ISealable.Seal() failed after ISealable.CanSeal returned true");
                    }
                    else
                    {
                        throw new ArgumentException(SR.Get(SRID.DefaultValueMustBeFreeThreaded, propertyName));
                    }
                }
            }
