    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LFU {
    
        class LFUCache<TKey,TValue> {
    
            Dictionary<TKey, LinkedListNode<CacheNode>> cache = new Dictionary<TKey, LinkedListNode<CacheNode>>();
            LinkedList<CacheNode> lfuList = new LinkedList<CacheNode>();
    
            class CacheNode {
                public TKey Key { get; set; }
                public TValue Data { get; set; }
                public int UseCount { get; set; }
            } 
    
            int size;
            int age = 0;
            int agePolicy;
    
            public LFUCache(int size) : this(size, 1000) {
            }
            
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="size"></param>
            /// <param name="agePolicy">after age policy Gets the cache will take 1 off all UseCounts</param>
            public LFUCache(int size, int agePolicy) {
                this.agePolicy = 1000;
                this.size = size;
            }
    
            public void Add(TKey key, TValue val) {
                TValue existing;
                if (!TryGet(key, out existing)) {
                    var node = new CacheNode() {Key = key, Data = val, UseCount = 1};
                    if (lfuList.Count == size) {
                        cache.Remove(lfuList.First.Value.Key);
                        lfuList.RemoveFirst();
                    }
    
                    var insertionPoint = Nodes.LastOrDefault(n => n.Value.UseCount < 2);
    
                    LinkedListNode<CacheNode> inserted; 
    
                    if (insertionPoint == null) {
                        inserted = lfuList.AddFirst(node);
                    } else {
                        inserted = lfuList.AddAfter(insertionPoint, node);
                    }
                    cache[key] = inserted;
                }
            }
    
            IEnumerable<LinkedListNode<CacheNode>> Nodes {
                get {
                    var node = lfuList.First;
                    while (node != null) {
                        yield return node;
                        node = node.Next;
                    }
                }
            }
    
            IEnumerable<LinkedListNode<CacheNode>> IterateFrom(LinkedListNode<CacheNode> node) {
                while (node != null) {
                    yield return node;
                    node = node.Next;
                }
            }
    
            public TValue GetOrDefault(TKey key) {
                TValue val;
                TryGet(key, out val);
                return val;
            }
    
            public bool TryGet(TKey key, out TValue val) {
    
                age++;
                if (age > agePolicy) {
                    age = 0;
                    foreach (var node in cache.Values) {
                        var v = node.Value;
                        v.UseCount--;
                    }
                }
                
                LinkedListNode<CacheNode> data;
                bool success = false;
    
                if (cache.TryGetValue(key, out data)) {
                    var cacheNode = data.Value;
                    val = cacheNode.Data;
                    cacheNode.UseCount++;
    
                    var insertionPoint = IterateFrom(data).Last(n => n.Value.UseCount <=  cacheNode.UseCount);
    
                    if (insertionPoint != data) {
                        lfuList.Remove(data);
                        lfuList.AddAfter(insertionPoint, data);
                    }
    
                } else {
                    val = default(TValue);
                }
    
                return success;
            }
        }
        
        class Program {
    
    
            public static void Assert(bool condition, string message) {
                if (!condition) {
                    Console.WriteLine("Assert failed : " + message);
                    throw new ApplicationException("Test Failed"); 
                }
            }
            
            public static void RunAllTests(Program prog){
                foreach (var method in prog.GetType().GetMethods()) {
                    if (method.Name.StartsWith("Test")) {
                        try {
                            method.Invoke(prog, null);
                            Console.WriteLine("Test Passed: " + method.Name);
                        } catch (Exception) {
                            Console.WriteLine("Test Failed : " + method.Name);
                        }
                        
                    }
                }
            }
    
            public void TestItemShouldBeThereOnceInserted() {
                var cache = new LFUCache<string, int>(3);
    
                cache.Add("a", 1);
                cache.Add("b", 2);
                cache.Add("c", 3);
                cache.Add("d", 4); 
    
                Assert(cache.GetOrDefault("a") == 0, "should get 0");
                Assert(cache.GetOrDefault("b") == 2, "should get 2");
                Assert(cache.GetOrDefault("c") == 3, "should get 3");
                Assert(cache.GetOrDefault("d") == 4, "should get 4");
            }
    
            public void TestLFUShouldWorkAsExpected() {
    
                var cache = new LFUCache<string, int>(3);
    
                cache.Add("a", 1);
                cache.Add("b", 2);
                cache.Add("c", 3);
    
                cache.GetOrDefault("a");
                cache.GetOrDefault("a");
                cache.GetOrDefault("b");
    
                cache.Add("d", 4);
                cache.Add("e", 5);
    
    
                Assert(cache.GetOrDefault("a") == 1, "should get 1");
                Assert(cache.GetOrDefault("b") == 2, "should get 0");
                Assert(cache.GetOrDefault("c") == 0, "should get 0");
                Assert(cache.GetOrDefault("d") == 0, "should get 4");
                Assert(cache.GetOrDefault("e") == 5, "should get 5");
                
            } 
    
    
            static void Main(string[] args) {
                RunAllTests(new Program());
                Console.ReadKey();
            }
    
    
        }
    }
