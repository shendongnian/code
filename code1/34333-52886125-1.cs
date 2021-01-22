    [TestFixture]
    public class GetAttributesTest
    {
        [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
        private sealed class A : Attribute
        {
            // default equality for Attributes is apparently semantic
            public override bool Equals(object obj)
            {
                return ReferenceEquals(this, obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
        private sealed class ANotInherited : Attribute { }
        public interface Top
        {
            [A, ANotInherited]
            void M();
            [A, ANotInherited]
            int P { get; }
        }
        public interface Middle : Top { }
        private abstract class Base
        {
            [A, ANotInherited]
            public abstract void M();
            [A, ANotInherited]
            public abstract int P { get; }
        }
        private class Bottom : Base, Middle
        {
            [A, ANotInherited]
            public override void M()
            {
                throw new NotImplementedException();
            }
            [A, ANotInherited]
            public override int P { get { return 42; } }
        }
        [Test]
        public void GetsAllInheritedAttributesOnMethods()
        {
            var attributes = typeof (Bottom).GetMethod("M").GetAttributes<A>();
            attributes.Should()
                .HaveCount(3, "there are 3 inherited copies in the class heirarchy and A is inherited");
        }
        [Test]
        public void DoesntGetNonInheritedAttributesOnMethods()
        {
            var attributes = typeof (Bottom).GetMethod("M").GetAttributes<ANotInherited>();
            attributes.Should()
                .HaveCount(1, "it shouldn't get copies of the attribute from base classes for a non-inherited attribute");
        }
        [Test]
        public void GetsAllInheritedAttributesOnProperties()
        {
            var attributes = typeof(Bottom).GetProperty("P").GetAttributes<A>();
            attributes.Should()
                .HaveCount(3, "there are 3 inherited copies in the class heirarchy and A is inherited");
        }
        [Test]
        public void DoesntGetNonInheritedAttributesOnProperties()
        {
            var attributes = typeof(Bottom).GetProperty("P").GetAttributes<ANotInherited>();
            attributes.Should()
                .HaveCount(1, "it shouldn't get copies of the attribute from base classes for a non-inherited attribute");
        }
    }
