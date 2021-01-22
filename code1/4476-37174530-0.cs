        // Author: Giovanni Costagliola <giovanni.costagliola@gmail.com>
    
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        namespace Utils
        {
        /// <summary>
        /// Represent a Weighted Item.
        /// </summary>
        public interface IWeighted
        {
            /// <summary>
            /// A positive weight. It's up to the implementer ensure this requirement
            /// </summary>
            int Weight { get; }
        }
    
        /// <summary>
        /// Pick up an element reflecting its weight.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class RandomWeightedPicker<T> where T:IWeighted
        {
            private readonly IEnumerable<T> items;
            private readonly int totalWeight;
            private Random random = new Random();
    
            /// <summary>
            /// Initiliaze the structure. O(1) or O(n) depending by the options, default O(n).
            /// </summary>
            /// <param name="items">The items</param>
            /// <param name="checkWeights">If <c>true</c> will check that the weights are positive. O(N)</param>
            /// <param name="shallowCopy">If <c>true</c> will copy the original collection structure (not the items). Keep in mind that items lifecycle is impacted.</param>
            public RandomWeightedPicker(IEnumerable<T> items, bool checkWeights = true, bool shallowCopy = true)
            {
                if (items == null) throw new ArgumentNullException("items");
                if (!items.Any()) throw new ArgumentException("items cannot be empty");
                if (shallowCopy)
                    this.items = new List<T>(items);
                else
                    this.items = items;
                if (checkWeights && this.items.Any(i => i.Weight <= 0))
                {
                    throw new ArgumentException("There exists some items with a non positive weight");
                }
                totalWeight = this.items.Sum(i => i.Weight);
            }
            /// <summary>
            /// Pick a random item based on its chance. O(n)
            /// </summary>
            /// <param name="defaultValue">The value returned in case the element has not been found</param>
            /// <returns></returns>
            public T PickAnItem()
            {
                int rnd = random.Next(totalWeight);
                return items.First(i => (rnd -= i.Weight) < 0);
            }
    
            /// <summary>
            /// Resets the internal random generator. O(1)
            /// </summary>
            /// <param name="seed"></param>
            public void ResetRandomGenerator(int? seed)
            {
                random = seed.HasValue ? new Random(seed.Value) : new Random();
            }
        }
    }
    
