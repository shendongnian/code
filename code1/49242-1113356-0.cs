        // --------------------------------------------------------------------
        // USING THE ESSENCE LIBRARY:
        // --------------------------------------------------------------------
        [EssenceClass(UseIn = EssenceFunctions.All)]
        public class TestEssence : IEquatable<TestEssence>, IComparable<TestEssence>
        {
            [Essence(Order=0] public int MyInt           { get; set; }
            [Essence(Order=1] public string MyString     { get; set; }
            [Essence(Order=2] public DateTime MyDateTime { get; set; }
            public override int GetHashCode()                                { return Essence<TestEssence>.GetHashCodeStatic(this); }
	    ...
        }
        // --------------------------------------------------------------------
        // EQUIVALENT HAND WRITTEN CODE:
        // --------------------------------------------------------------------
        public class TestManual
        {
            public int MyInt;
            public string MyString;
            public DateTime MyDateTime;
            public override int GetHashCode()
            {
                var x = MyInt.GetHashCode();
                x *= Essence<TestEssence>.HashCodeMultiplier;
                x ^= (MyString == null) ? 0 : MyString.GetHashCode();
                x *= Essence<TestEssence>.HashCodeMultiplier;
                x ^= MyDateTime.GetHashCode();
                return x;
            }
	    ...
        }
