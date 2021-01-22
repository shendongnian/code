        enum Colour
        {
            Red,
            Blue
        }
        private void ParseColours()
        {
            Colour aColour;
            // IMO using the actual enum type is intuitive, but Resharper gives 
            // "Access to a static member of a type via a derived type"
            if (Colour.TryParse("RED", true, out aColour))
            {
               // ... success
            }
            // OR, the compiler can infer the type from the out
            if (Enum.TryParse("Red", out aColour))
            {
               // ... success
            }
            // OR explicit type specification
            // (Resharper: Type argument specification is redundant)
            if (Enum.TryParse<Colour>("Red", out aColour))
            {
              // ... success
            }
        }
