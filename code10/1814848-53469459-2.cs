    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Text;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dataList = GetMockData();
    
                var isInTree = dataList.FoundInTree(searchItem: item => item.Id == 6,
                                                    nestedItems: item => item.NestedData,
                                                    out int foundCount);
    
                if (isInTree)
                {
                    Console.WriteLine($"Found {foundCount} items in the tree.");
                }
                else
                {
                    Console.WriteLine("None found in the tree.");
                }
    
                var removedFromTree = dataList.RemoveAllFromTree(searchItem: item => item.Id == 6,
                                                                 nestedItems: item => item.NestedData,
                                                                 out int removedCount);
    
                if (removedFromTree)
                {
                    Console.WriteLine($"Removed {removedCount} items from the tree.");
                }
                else
                {
                    Console.WriteLine($"No items removed from the tree.");
                }
    
                isInTree = dataList.FoundInTree(searchItem: SearchItem,
                                               nestedItems: (item) => item.NestedData);
    
                if (isInTree)
                {
                    Console.WriteLine($"Found {foundCount} items in the tree.");
                }
                else
                {
                    Console.WriteLine("None found in the tree.");
                }
    
    
                Console.ReadKey();
            }
    
            private static List<Data<int>> GetMockData()
            {
                var dataList = new List<Data<int>>();
    
                for (var i = 0; i < 7; i++)
                {
                    dataList.Add(getData(i));
                }
    
                return dataList;
    
                Data<int> getData(int count)
                {
                    var data = new Data<int>
                    {
                        Id = count
                    };
    
                    for (var j = count; j > 0; j--)
                    {
                        var innerData = new Data<int>
                        {
                            Id = j
                        };
    
                        innerData.NestedData.Add(getData(--j));
                        data.NestedData.Add(innerData);
                    }
    
                    return data;
                }
            }
        }
    
        public class Data<T>
        {
            public T Id { get; set; }
            public List<Data<T>> NestedData { get; set; } = new List<Data<T>>();
        }
    
        public static class Extensions
        {
            public static bool FoundInTree<T>(this IEnumerable<T> items, Func<T, bool> searchItem, Func<T, IEnumerable<T>> nestedItems)
            {
                foreach (var item in items)
                {
                    if (searchItem.Invoke(item)) return true;
                    if (nestedItems.Invoke(item).FoundInTree(searchItem, nestedItems)) return true;
                }
                return false;
            }
    
            public static bool RemoveFirstFromTree<T>(this ICollection<T> items, Func<T, bool> searchItem, Func<T, ICollection<T>> nestedItems)
            {
                foreach (var item in items.ToList())
                {
                    if (searchItem.Invoke(item))
                    {
                        items.Remove(item);
                        return true;
                    }
                    if (nestedItems.Invoke(item).RemoveFirstFromTree(searchItem, nestedItems))
                    {
                        return true;
                    }
                }
                return false;
            }
    
            public static bool FoundInTree<T>(this IEnumerable<T> items, Func<T, bool> searchItem, Func<T, IEnumerable<T>> nestedItems, out int count)
            {
                count = 0;
                foreach (var item in items)
                {
                    if (searchItem.Invoke(item)) count++;
                    if (nestedItems.Invoke(item).FoundInTree(searchItem, nestedItems, out int nestedCount)) count += nestedCount;
                }
                return count > 0;
            }
    
            public static bool RemoveAllFromTree<T>(this ICollection<T> items, Func<T, bool> searchItem, Func<T, ICollection<T>> nestedItems, out int count)
            {
                var isAnyRemoved = false;
                count = 0;
                foreach (var item in items.ToList())
                {
                    if (searchItem.Invoke(item))
                    {
                        items.Remove(item);
                        isAnyRemoved = true;
                        count++;
                    }
                    if (nestedItems.Invoke(item).RemoveAllFromTree(searchItem, nestedItems, out int nestedCount))
                    {
                        isAnyRemoved = true;
                        count += nestedCount;
                    }
                }
                return isAnyRemoved;
            }
        }
    }
