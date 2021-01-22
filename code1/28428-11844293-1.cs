    /// <summary>
    /// Extension methods for <see cref="System.Collections.Generic.List{T}"/>
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in a list.
        /// </summary>
        public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.NotNull(itemSelector, "itemSelector");
            Ensure.Argument.Is(newIndex >= 0, "New index must be greater than or equal to zero.");
            
            var currentIndex = list.FindIndex(itemSelector);
            Ensure.That<ArgumentException>(currentIndex >= 0, "No item was found that matches the specified selector.");
            // Copy the current item
            var item = list[currentIndex];
            // Remove the item
            list.RemoveAt(currentIndex);
            // Finally add the item at the new index
            list.Insert(newIndex, item);
        }
    }
    [Subject(typeof(ListExtensions), "Move")]
    public class List_Move
    {
        static List<int> list;
        public class When_no_matching_item_is_found
        {
            static Exception exception;
            Establish ctx = () => {
                list = new List<int>();
            };
            Because of = ()
                => exception = Catch.Exception(() => list.Move(x => x == 10, 10));
            It Should_throw_an_exception = ()
                => exception.ShouldBeOfType<ArgumentException>();
        }
        public class When_new_index_is_higher
        {
            Establish ctx = () => {
                list = new List<int> { 1, 2, 3, 4, 5 };
            };
            Because of = ()
                => list.Move(x => x == 3, 4); // move 3 to end of list (index 4)
            It Should_be_moved_to_the_specified_index = () =>
                {
                    list[0].ShouldEqual(1);
                    list[1].ShouldEqual(2);
                    list[2].ShouldEqual(4);
                    list[3].ShouldEqual(5);
                    list[4].ShouldEqual(3);
                };
        }
        public class When_new_index_is_lower
        {
            Establish ctx = () => {
                list = new List<int> { 1, 2, 3, 4, 5 };
            };
            Because of = ()
                => list.Move(x => x == 4, 0); // move 4 to beginning of list (index 0)
            It Should_be_moved_to_the_specified_index = () =>
            {
                list[0].ShouldEqual(4);
                list[1].ShouldEqual(1);
                list[2].ShouldEqual(2);
                list[3].ShouldEqual(3);
                list[4].ShouldEqual(5);
            };
        }
    }
