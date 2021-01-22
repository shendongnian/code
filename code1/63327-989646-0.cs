    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Collections.ObjectModel;
    using System.Reflection;
    
    namespace CopyCollection {
    
      class CFoo {
        public int Key;
        public string Name;
      }
    
      class MyKeyedCollection : KeyedCollection<int, CFoo> {
        public MyKeyedCollection() : base(null, 10) { }
        protected override int GetKeyForItem(CFoo foo) {
          return foo.Key;
        }
      }
    
      class MyObject {
        public MyKeyedCollection kc;
    
        // Copy constructor
        public MyObject(MyObject that) {
          this.kc = new MyKeyedCollection();
          if (that != null) {
            CollectionTools.CopyKeyedCollection<int, CFoo>(that.kc, this.kc);
          }
        }
      }
    
      class Program {
    
        static void Main(string[] args) {
    
          MyObject mobj1 = new MyObject(null);
          for (int i = 0; i < 7; ++i)
            mobj1.kc.Add(new CFoo() { Key = i, Name = i.ToString() });
          // Copy mobj1
          MyObject mobj2 = new MyObject(mobj1);
          // add a bunch more items to mobj2
          for (int i = 8; i < 712324; ++i)
            mobj2.kc.Add(new CFoo() { Key = i, Name = i.ToString() });
          // copy mobj2
          MyObject mobj3 = new MyObject(mobj2);
          // put a breakpoint after here, and look at mobj's and see that it worked!
          // you can delete stuff out of mobj1 or mobj2 and see the items still in mobj3,
          // because mobj3 is not a reference to mobj2
        }
      }
    
      public static class CollectionTools {
    
        public unsafe static KeyedCollection<TKey, TValue> CopyKeyedCollection<TKey, TValue>(KeyedCollection<TKey, TValue> src, KeyedCollection<TKey, TValue> dst) {
    
          object osrc = src;
          TKeyedCollection* psrc = (TKeyedCollection*)(*((int*)&psrc + 1));  // pointer to a structure that is a template for the instance variables of KeyedCollection<TKey, TValue>
          object odst = dst;
          TKeyedCollection* pdst = (TKeyedCollection*)(*((int*)&pdst + 1));
          object srcObj = null;
          object dstObj = null;
          int* i = (int*)&i;  // helps me find the stack
    
          i[2] = (int)psrc->_01_items;
          dstObj = CopyList<TValue>(srcObj as List<TValue>);
          pdst->_01_items = (uint)i[1];
    
          if (psrc->_04_dict != 0) {
            i[2] = (int)psrc->_04_dict;
            dstObj = CopyDict<TKey, TValue>(srcObj as Dictionary<TKey, TValue>);
            pdst->_04_dict = (uint)i[1];
          }
    
          pdst->_03_comparer = psrc->_03_comparer;
          pdst->_05_keyCount = psrc->_05_keyCount;
          pdst->_06_threshold = psrc->_06_threshold;
          return dst;
        }
    
        public unsafe static List<TValue> CopyList<TValue>(List<TValue> src) {
    
          object osrc = src;
          TList* psrc = (TList*)(*((int*)&psrc + 1));  // pointer to a structure that is a template for the instance variables of List<>
          object srcArray = null;
          object dstArray = null;
          int* i = (int*)&i;  // helps me find things on stack
    
          i[2] = (int)psrc->_01_items;
          int capacity = (srcArray as Array).Length;
          List<TValue> dst = new List<TValue>(capacity);
          TList* pdst = (TList*)(*((int*)&pdst + 1));
          i[1] = (int)pdst->_01_items;
          Array.Copy(srcArray as Array, dstArray as Array, capacity);
    
          pdst->_03_size = psrc->_03_size;
    
          return dst;
        }
    
        public unsafe static Dictionary<TKey, TValue> CopyDict<TKey, TValue>(Dictionary<TKey, TValue> src) {
    
          object osrc = src;
          TDictionary* psrc = (TDictionary*)(*((int*)&psrc + 1));  // pointer to a structure that is a template for the instance variables of Dictionary<TKey, TValue>
          object srcArray = null;
          object dstArray = null;
          int* i = (int*)&i;  // helps me find the stack
    
          i[2] = (int)psrc->_01_buckets;
          int capacity = (srcArray as Array).Length;
          Dictionary<TKey, TValue> dst = new Dictionary<TKey, TValue>(capacity);
          TDictionary* pdst = (TDictionary*)(*((int*)&pdst + 1));
          i[1] = (int)pdst->_01_buckets;
          Array.Copy(srcArray as Array, dstArray as Array, capacity);
    
          i[2] = (int)psrc->_02_entries;
          i[1] = (int)pdst->_02_entries;
          Array.Copy(srcArray as Array, dstArray as Array, capacity);
    
          pdst->_03_comparer = psrc->_03_comparer;
          pdst->_04_m_siInfo = psrc->_04_m_siInfo;
          pdst->_08_count = psrc->_08_count;
          pdst->_10_freeList = psrc->_10_freeList;
          pdst->_11_freeCount = psrc->_11_freeCount;
    
          return dst;
        }
    
        struct TKeyedCollection {
          public uint _00_MethodInfo;                   //
          // Collection
          public uint _01_items;                       // * IList<T>
          public uint _02_syncRoot;                   //   object
          // KeyedCollection
          public uint _03_comparer;                    //   IEqualityComparer<TKey> 
          public uint _04_dict;                        // * Dictionary<TKey, TItem> 
          public int _05_keyCount;                     // *
          public int _06_threshold;                    // *
          // const int defaultThreshold = 0;
        }
    
        struct TList {
          public uint _00_MethodInfo;                   //
          public uint _01_items;                      // * T[] 
          public uint _02_syncRoot;                   //   object
          public int _03_size;                        // *
          public int _04_version;                     //
        }
    
        struct TDictionary {
          // Fields
          public uint _00_MethodInfo;                   //
          public uint _01_buckets;                     // * int[] 
          public uint _02_entries;                     // * Entry<TKey, TValue>[] 
          public uint _03_comparer;                    //   IEqualityComparer<TKey> 
          public uint _04_m_siInfo;                    //   SerializationInfo
          public uint _05__syncRoot;                   //   object 
          public uint _06_keys;                        //   KeyCollection<TKey, TValue> 
          public uint _07_values;                      //   ValueCollection<TKey, TValue> 
          public int _08_count;                        // *
          public int _09_version;
          public int _10_freeList;                     // * 
          public int _11_freeCount;                    // *
        }
    
      }
    
    
    }
