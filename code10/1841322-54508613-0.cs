    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace SandboxNetStandard
    {
        public static class ListAdapter<T>
        {
            private static readonly FieldInfo _arrayField = typeof(List<T>)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(x => x.FieldType == typeof(T[]));
    
            /// <summary>
            /// Converts
            /// <paramref name="listIPromiseToNotChangeTheCountOfAndNotCauseCapacityToChange"/>
            /// to an <see cref="Memory{T}"/>.
            /// </summary>
            /// <param name="listIPromiseToNotChangeTheCountOfAndNotCauseCapacityToChange">
            /// The list to convert.
            ///
            /// On each use of the returned memory object the list must have the same value of
            /// <see cref="List{T}.Count"/> as the original passed in value. Also between calls 
            /// you must not do any action that would cause the internal array of the list to
            /// be swapped out with another array.
            /// </param>
            /// <returns>
            /// A <see cref="Memory{T}"/> that is linked to the passed in list.
            /// </returns>
            public static Memory<T> ToMemory(
                List<T> listIPromiseToNotChangeTheCountOfAndNotCauseCapacityToChange)
            {
                Memory<T> fullArray = (T[]) _arrayField.GetValue(
                        listIPromiseToNotChangeTheCountOfAndNotCauseCapacityToChange);
                return fullArray.Slice(0,
                    listIPromiseToNotChangeTheCountOfAndNotCauseCapacityToChange.Count);
            }
        }
    }
