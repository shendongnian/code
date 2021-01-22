    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections;
    
    namespace TestLibrary
    {
        [Serializable]
        [XmlRoot("Objects")]
        public class ObjectTest : ICollection
        {
            [XmlArray("Items")]
            public Items[] items;
    
            #region "Required for implementing ICollection"
            //Default Accessor
            public Items this[int index]
            {
                get { return (Items)items[index]; }
            }
    
            public void CopyTo(Array array, int index)
            {
                items.CopyTo(array, index);
            }
    
            public int Count
            {
                get { return items.Length; }
            }
    
            public bool IsSynchronized
            {
                get { return false; }
            }
    
            public object SyncRoot
            {
                get { return this; }
            }
    
    
    
            public IEnumerator GetEnumerator()
            {
                return items.GetEnumerator();
            }
    
            public void Add(Items newItems)
            {
                if (this.items == null)
                {
                    this.items = new Items[1];
                }
                else
                {
                    Array.Resize(ref this.items, this.items.Length + 1);
                }
                this.items[this.items.GetUpperBound(0)] = newItems;
    
            }
            #endregion
        }
    
        [Serializable]
        public class Items
        {
            [XmlElement("Item")]
            public Item item;
    
    
    
        }
        [Serializable]
        public class Item
        {
            [XmlAttribute("itemType")]
            public string itemType;
    
    
            [XmlArray("SearchField")]
            public SearchFields[] searchfields;
        }
    
        [Serializable]
        public class SearchFields
        {
    
            [XmlAttribute("name")]
            public string searchName;
    
            [XmlAttribute("value")]
            public string searchValue;
    
        }
    
    
    }
