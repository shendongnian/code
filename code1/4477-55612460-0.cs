    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class WeightedList<T>
    {
        private readonly Dictionary<T,int> _items = new Dictionary<T,int>();
        
        // Doesn't allow items with zero weight; to remove an item, set its weight to zero
        public void SetWeight(T item, int weight)
        {
            if (_items.ContainsKey(item))
            {
                if (weight != _items[item])
                {
                    if (weight > 0)
                    {
                        _items[item] = weight;
                    }
                    else
                    {
                        _items.Remove(item);
                    }
    
                    _totalWeight = null; // Will recalculate the total weight later
                }
            }
            else if (weight > 0)
            {
                _items.Add(item, weight);
                
                _totalWeight = null; // Will recalculate the total weight later
            }
        }
    
        public int GetWeight(T item)
        {
            return _items.ContainsKey(item) ? _items[item] : 0;
        }
        
        private int? _totalWeight;
        public int totalWeight
        {
            get
            {
                if (!_totalWeight.HasValue) _totalWeight = _items.Sum(x => x.Value);
                
                return _totalWeight.Value;
            }
        }
    
        public T Random
        {
            get
            {
                var temp = 0;
                var random = new Random().Next(totalWeight);
        
                foreach (var item in _items)
                {
                    temp += item.Value;
        
                    if (random < temp) return item.Key;
                }
                
                throw new Exception($"unable to determine random {typeof(T)} at {random} in {totalWeight}");
            }
        }
    }
