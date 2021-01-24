    public static class EqualityHelper
    {
        public static bool? EqualsQuickReject<T1, T2>(T1 item1, T2 item2) 
            where T1 : class
            where T2 : class
        {
            if ((object)item1 == (object)item2)
                return true;
            else if ((object)item1 == null || (object)item2 == null)
                return false;
            if (item1.GetType() != item2.GetType())
                return false;
            return null;
        }
    }
    public class EntityA : IEquatable<EntityA> //Fixed added IEquatable<T>
    {
        public int Foo { get; set; } // FIXED made public
        public override bool Equals(object obj)
        {
            return Equals(obj as EntityA);
        }
        // Fixed added required GetHashCode() that is compatible with Equals()
        public override int GetHashCode()
        {
            return Foo.GetHashCode();
        }
        #region IEquatable<EntityA> Members
        public bool Equals(EntityA other)
        {
            // FIXED - ensure Equals is reflexive, symmetric and transitive even when dealing with derived types
            var initial = EqualityHelper.EqualsQuickReject(this, other);
            if (initial != null)
                return initial.Value;
            return this.Foo == other.Foo;
        }
        #endregion
    }
    public class EntityB : IEquatable<EntityB> //Fixed added IEquatable<T>
    {
        public int Bar { get; set; } // FIXED made public
        public EntityA Parent { get; set; } // FIXED made public
        public override bool Equals(object obj)
        {
            return Equals(obj as EntityB);
        }
        // Fixed added required GetHashCode() that is compatible with Equals()
        public override int GetHashCode()
        {
            return Bar.GetHashCode();
        }
        #region IEquatable<EntityB> Members
        public bool Equals(EntityB other)
        {
            // FIXED - ensure Equals is reflexive, symmetric and transitive even when dealing with derived types
            var initial = EqualityHelper.EqualsQuickReject(this, other);
            if (initial != null)
                return initial.Value;
            return this.Bar == other.Bar;
        }
        #endregion
    }
    public class InnerWrapper
    {
        public string FooBar { get; set; }
        public EntityB BEntity { get; set; }
    }
    public class OuterClass
    {
        public EntityA AEntity { get; set; }
        public List<EntityB> InnerElements { get; set; }//FIXED -- made public and corrected type to be consistent with sample JSON
    }
