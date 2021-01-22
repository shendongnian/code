        public static Tout CopyValue<Tin, Tout>(Tin from, Tout toPrototype)
        {
            Type underlyingT = Nullable.GetUnderlyingType(typeof(Tout));
            if (underlyingT == null)
            { return (Tout)Convert.ChangeType(from, typeof(Tout)); }
            else
            { return (Tout)Convert.ChangeType(from, underlyingT); }
        }
