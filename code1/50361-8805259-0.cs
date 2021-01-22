    using System.Collections;
    using System.Collections.Generic;
    
    namespace UDF.MyDataLayer
    {
        internal class ListCastAdapter<S,T> : IList<T> where T : class where S : class
        {
            private List<S> adaptee;
    
            public ListCastAdapter(List<S> adaptee )
            {
                this.adaptee = adaptee;
            }
    
            #region Implementation of IEnumerable
    
            public class EnumeratorCastAdapter : IEnumerator<T>
            {
                private IEnumerator<S> adaptee;
    
                public EnumeratorCastAdapter(IEnumerator<S> adaptee)
                {
                    this.adaptee = adaptee;
                }
    
                #region Implementation of IDisposable
                
                /// <summary>
                /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
                /// </summary>
                /// <filterpriority>2</filterpriority>
                public void Dispose()
                {
                    adaptee.Dispose();
                }
    
                #endregion
    
                #region Implementation of IEnumerator
                /// <summary>
                /// Advances the enumerator to the next element of the collection.
                /// </summary>
                /// <returns>
                /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
                /// </returns>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
                public bool MoveNext()
                {
                    return adaptee.MoveNext();
                }
    
                /// <summary>
                /// Sets the enumerator to its initial position, which is before the first element in the collection.
                /// </summary>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
                public void Reset()
                {
                    adaptee.Reset();
                }
    
                /// <summary>
                /// Gets the element in the collection at the current position of the enumerator.
                /// </summary>
                /// <returns>
                /// The element in the collection at the current position of the enumerator.
                /// </returns>
                public T Current
                {
                    get
                    {
                        // needs to check if it is an Object or Value Type
                        return adaptee.Current as T;
                    }
                }
    
                /// <summary>
                /// Gets the current element in the collection.
                /// </summary>
                /// <returns>
                /// The current element in the collection.
                /// </returns>
                /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception><filterpriority>2</filterpriority>
                object IEnumerator.Current
                {
                    get { return Current; }
                }
                #endregion
            }
            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
            /// </returns>
            /// <filterpriority>1</filterpriority>
            public IEnumerator<T> GetEnumerator()
            {
                return new EnumeratorCastAdapter(adaptee.GetEnumerator());
            }
    
            /// <summary>
            /// Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return adaptee.GetEnumerator();
            }
            #endregion
    
            #region Implementation of ICollection<T>
            /// <summary>
            /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
            public void Add(T item)
            {
                adaptee.Add(item as S);
            }
    
            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
            public void Clear()
            {
                adaptee.Clear();
            }
    
            /// <summary>
            /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
            /// </summary>
            /// <returns>
            /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
            /// </returns>
            /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
            public bool Contains(T item)
            {
                return adaptee.Contains(item as S);
            }
    
            /// <summary>
            /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.-or-Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new System.NotImplementedException("Not Needed by Me, implement ArrayCastAdapter if needed");
            }
    
            /// <summary>
            /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <returns>
            /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </returns>
            /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
            public bool Remove(T item)
            {
                adaptee.Remove(item as S);
            }
    
            /// <summary>
            /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <returns>
            /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </returns>
            public int Count
            {
                get { return adaptee.Count; }
            }
    
            /// <summary>
            /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
            /// </summary>
            /// <returns>
            /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
            /// </returns>
            public bool IsReadOnly
            {
                get 
                {
                    return true;  // change, to live on the edge
                }
            }
            #endregion
    
            #region Implementation of IList<T>
            /// <summary>
            /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
            /// </summary>
            /// <returns>
            /// The index of <paramref name="item"/> if found in the list; otherwise, -1.
            /// </returns>
            /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
            public int IndexOf(T item)
            {
                return adaptee.IndexOf(item as S);
            }
    
            /// <summary>
            /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
            public void Insert(int index, T item)
            {
                adaptee.Insert(index, item as S);
            }
    
            /// <summary>
            /// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the item to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
            public void RemoveAt(int index)
            {
                adaptee.RemoveAt(index);
            }
    
            /// <summary>
            /// Gets or sets the element at the specified index.
            /// </summary>
            /// <returns>
            /// The element at the specified index.
            /// </returns>
            /// <param name="index">The zero-based index of the element to get or set.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
            public T this[int index]
            {
                get { return adaptee[index] as T; }
                set { adaptee[index] = value as S; }
            }
            #endregion
        }
    }
