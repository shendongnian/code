        /// <summary>
        ///   Gets the index of a given <paramref name="component"/> of the <see cref="List{T}"/>.
        /// </summary>
        /// <returns>The index of a given <paramref name="component"/> of the <see cref="List{T}"/>.</returns>
        /// <param name="value">The <see cref="List{T}"/> to find the <paramref name="component"/> in.</param>
        /// <param name="component">The component to find.</param>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        public static int? GetIndex<T> (this List<T> value, T component)
        {
            // Checks each index of value for component.
            for (int i = 0; i < value.ToArray().Length; ++i)
                if (value[i].Equals(component)) return i;
            // Returns null if there is no match
            return null;
        }
