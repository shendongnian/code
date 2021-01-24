    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackOverflowTests
    {
        [TestClass]
        public class StackOverflow_49181925Tests
        {
            public interface IHasId
            {
                int Id { get; set; }
            }
    
            public class Foo : IHasId
            {
                public int Id { get; set; }
            }
    
            public class HasAFoo
            {
                public Foo Foo { get; set; }
            }
    
            public class HasManyFoos
            {
                public IEnumerable<Foo> Foos { get; set; }
            }
    
            public void SetPropertyIds(object target, string propertyName, IEnumerable<int> ids)
            {
                var property = target.GetType().GetProperty(propertyName);
                var propertyType = property.PropertyType;
    
                //is it enumerable?
                if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    var objectType = propertyType.GetGenericArguments().First();
    
                    var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(objectType)) as IList;
    
                    foreach(var id in ids)
                    {
                        var obj = Activator.CreateInstance(objectType) as IHasId;
                        ((IHasId)obj).Id = id;
    
                        list.Add(obj);
                    }
    
                    property.SetValue(target, list);
                }
                else
                {
                    if(ids.Count() != 1) throw new ApplicationException("You're trying to set multiple Ids to a single property.");
                    var objectType = propertyType;
                    var obj = Activator.CreateInstance(objectType);
                    ((IHasId)obj).Id = ids.First();
                    property.SetValue(target, obj);
                }
            }  
    
            [TestMethod]
            public void TestHasAFoo()
            {
                var target = new HasAFoo();
                this.SetPropertyIds(target, "Foo", new[] { 1 });
                Assert.AreEqual(target.Foo.Id, 1);
            }
    
            [TestMethod]
            public void TestHasManyFoos()
            {
                var target = new HasManyFoos();
                this.SetPropertyIds(target, "Foos", new[] { 1, 2 });
                Assert.AreEqual(target.Foos.ElementAt(0).Id, 1);
                Assert.AreEqual(target.Foos.ElementAt(1).Id, 2);
            }
        }
    }
