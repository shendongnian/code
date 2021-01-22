    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    
    namespace StackOverflow.EmptyCollectionUsageTests.Tests
    {
        /// <summary>
        /// Demonstrates different approaches for empty collection results.
        /// </summary>
        class Container
        {
            /// <summary>
            /// Elements list.
            /// Not initialized to an empty collection here for the purpose of demonstration of usage along with <see cref="Populate"/> method.
            /// </summary>
            private List<Element> elements;
    
            /// <summary>
            /// Gets elements if any
            /// </summary>
            /// <returns>Returns elements or empty collection.</returns>
            public IEnumerable<Element> GetElements()
            {
                return elements ?? Enumerable.Empty<Element>();
            }
    
            /// <summary>
            /// Initializes the container with some results, if any.
            /// </summary>
            public void Populate()
            {
                elements = new List<Element>();
            }
    
            /// <summary>
            /// Gets elements. Throws <see cref="InvalidOperationException"/> if not populated.
            /// </summary>
            /// <returns>Returns <see cref="IEnumerable{T}"/> of <see cref="Element"/>.</returns>
            public IEnumerable<Element> GetElementsStrict()
            {
                if (elements == null)
                {
                    throw new InvalidOperationException("You must call Populate before calling this method.");
                }
    
                return elements;
            }
    
            /// <summary>
            /// Gets elements, empty collection or nothing.
            /// </summary>
            /// <returns>Returns <see cref="IEnumerable{T}"/> of <see cref="Element"/>, with zero or more elements, or null in some cases.</returns>
            public IEnumerable<Element> GetElementsInconvenientCareless()
            {
                return elements;
            }
    
            /// <summary>
            /// Gets elements or nothing.
            /// </summary>
            /// <returns>Returns <see cref="IEnumerable{T}"/> of <see cref="Element"/>, with elements, or null in case of empty collection.</returns>
            /// <remarks>We are lucky that elements is a List, otherwise enumeration would be needed.</remarks>
            public IEnumerable<Element> GetElementsInconvenientCarefull()
            {
                if (elements == null || elements.Count == 0)
                {
                    return null;
                }
                return elements;
            }
        }
    
        class Element
        {
        }
    
        /// <summary>
        /// http://stackoverflow.com/questions/1969993/is-it-better-to-return-null-or-empty-collection/
        /// </summary>
        class EmptyCollectionTests
        {
            private Container container;
    
            [SetUp]
            public void SetUp()
            {
                container = new Container();
            }
    
            /// <summary>
            /// Forgiving contract - caller does not have to implement null check in addition to enumeration.
            /// </summary>
            [Test]
            public void UseGetElements()
            {
                Assert.AreEqual(0, container.GetElements().Count());
            }
    
            /// <summary>
            /// Forget to <see cref="Container.Populate"/> and use strict method.
            /// </summary>
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void WrongUseOfStrictContract()
            {
                container.GetElementsStrict().Count();
            }
    
            /// <summary>
            /// Call <see cref="Container.Populate"/> and use strict method.
            /// </summary>
            [Test]
            public void CorrectUsaOfStrictContract()
            {
                container.Populate();
                Assert.AreEqual(0, container.GetElementsStrict().Count());
            }
    
            /// <summary>
            /// Inconvenient contract - needs a local variable.
            /// </summary>
            [Test]
            public void CarefulUseOfCarelessMethod()
            {
                var elements = container.GetElementsInconvenientCareless();
                Assert.AreEqual(0, elements == null ? 0 : elements.Count());
            }
    
            /// <summary>
            /// Inconvenient contract - duplicate call in order to use in context of an single expression.
            /// </summary>
            [Test]
            public void LameCarefulUseOfCarelessMethod()
            {
                Assert.AreEqual(0, container.GetElementsInconvenientCareless() == null ? 0 : container.GetElementsInconvenientCareless().Count());
            }
    
            [Test]
            public void LuckyCarelessUseOfCarelessMethod()
            {
                // INIT
                var praySomeoneCalledPopulateBefore = (Action)(()=>container.Populate());
                praySomeoneCalledPopulateBefore();
    
                // ACT //ASSERT
                Assert.AreEqual(0, container.GetElementsInconvenientCareless().Count());
            }
    
            /// <summary>
            /// Excercise <see cref="ArgumentNullException"/> because of null passed to <see cref="Enumerable.Count{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>
            /// </summary>
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void UnfortunateCarelessUseOfCarelessMethod()
            {
                Assert.AreEqual(0, container.GetElementsInconvenientCareless().Count());
            }
    
            /// <summary>
            /// Demonstrates the client code flow relying on returning null for empty collection.
            /// Exception is due to <see cref="Enumerable.First{TSource}(System.Collections.Generic.IEnumerable{TSource})"/> on an empty collection.
            /// </summary>
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void UnfortunateEducatedUseOfCarelessMethod()
            {
                container.Populate();
                var elements = container.GetElementsInconvenientCareless();
                if (elements == null)
                {
                    Assert.Inconclusive();
                }
                Assert.IsNotNull(elements.First());
            }
    
            /// <summary>
            /// Demonstrates the client code is bloated a bit, to compensate for implementation 'cleverness'.
            /// We can throw away the nullness result, because we don't know if the operation succeeded or not anyway.
            /// We are unfortunate to create a new instance of an empty collection.
            /// We might have already had one inside the implementation,
            /// but it have been discarded then in an effort to return null for empty collection.
            /// </summary>
            [Test]
            public void EducatedUseOfCarefullMethod()
            {
                Assert.AreEqual(0, (container.GetElementsInconvenientCarefull() ?? Enumerable.Empty<Element>()).Count());
            }
        }
    }
