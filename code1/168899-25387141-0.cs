    using System;
    using System.Reflection;
    using NUnit.Framework;
    namespace Playground
    {
        [TestFixture]
        public class EitherTests
        {
            [Test]
            public void Test_Either_of_Property_or_FieldInfo()
            {
                var some = new Some(false);
                var field = some.GetType().GetField("X");
                var property = some.GetType().GetProperty("Y");
                Assert.NotNull(field);
                Assert.NotNull(property);
                var info = Either<PropertyInfo, FieldInfo>.Of(field);
                var infoType = info.Match(p => p.PropertyType, f => f.FieldType);
                Assert.That(infoType, Is.EqualTo(typeof(bool)));
            }
            [Test]
            public void Either_of_three_cases_using_nesting()
            {
                var some = new Some(false);
                var field = some.GetType().GetField("X");
                var parameter = some.GetType().GetConstructors()[0].GetParameters()[0];
                Assert.NotNull(field);
                Assert.NotNull(parameter);
                var info = Either<ParameterInfo, Either<PropertyInfo, FieldInfo>>.Of(parameter);
                var name = info.Match(_ => _.Name, _ => _.Name, _ => _.Name);
                Assert.That(name, Is.EqualTo("a"));
            }
            public class Some
            {
                public bool X;
                public string Y { get; set; }
                public Some(bool a)
                {
                    X = a;
                }
            }
        }
        public static class Either
        {
            public static T Match<A, B, C, T>(
                this Either<A, Either<B, C>> source,
                Func<A, T> a = null, Func<B, T> b = null, Func<C, T> c = null)
            {
                return source.Match(a, bc => bc.Match(b, c));
            }
        }
        public abstract class Either<A, B>
        {
            public static Either<A, B> Of(A a)
            {
                return new CaseA(a);
            }
            public static Either<A, B> Of(B b)
            {
                return new CaseB(b);
            }
            public abstract T Match<T>(Func<A, T> a = null, Func<B, T> b = null);
            private sealed class CaseA : Either<A, B>
            {
                private readonly A _item;
                public CaseA(A item) { _item = item; }
                public override T Match<T>(Func<A, T> a = null, Func<B, T> b = null)
                {
                    return a == null ? default(T) : a(_item);
                }
            }
            private sealed class CaseB : Either<A, B>
            {
                private readonly B _item;
                public CaseB(B item) { _item = item; }
                public override T Match<T>(Func<A, T> a = null, Func<B, T> b = null)
                {
                    return b == null ? default(T) : b(_item);
                }
            }
        }
    }
