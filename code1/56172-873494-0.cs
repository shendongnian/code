    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Program
    {
       public static void Main(string[] args)
       {
          /* Tree Structure
    
             a
              d
               e   
             b
              f
              i
               j
             c
              g
               h
          */
    
          var a = new Category("a", null);
          var b = new Category("b", null);
          var c = new Category("c", null);
          var d = new Category("d", "a");
          var e = new Category("e", "d");
          var f = new Category("f", "b");
          var g = new Category("g", "c");
          var h = new Category("h", "g");
          var i = new Category("i", "b");
          var j = new Category("j", "i");
    
          var list = new CategoryCollection { j, i, h, g, f, e, d, c, b, a };
          foreach (var category in list.SortForTree())
          {
             Console.WriteLine("Name: {0}; Parent: {1}", category.Name, category.ParentCategoryID);
          }
       }
    }
    
    class Category
    {
       public string ParentCategoryID { get; set; }
       public string Name { get; set; }
       public Category(string name, string parentCategoryID)
       {
          Name = name;
          ParentCategoryID = parentCategoryID;
       }
    }
    
    class CategoryCollection : IEnumerable<Category>
    {
       private List<Category> list = new List<Category>();
    
       public void Add(Category category)
       {
          list.Add(category);
       }
    
       public IEnumerable<Category> SortForTree()
       {
          var target = new Dictionary<string, Category>();
    
          SortForTree(list, target);
    
          return target.Values;
       }
    
       private void SortForTree(IEnumerable<Category> source, Dictionary<string, Category> target)
       {
          var temp = new List<Category>();
    
          foreach (var c in source)
          {
             if (c.ParentCategoryID == null || (target.ContainsKey(c.ParentCategoryID) && !target.ContainsKey(c.Name)))
             {
                target.Add(c.Name, c);
             }
             else
             {
                temp.Add(c);
             }
          }
    
          if (temp.Count > 0) SortForTree(temp, target);
       }
    
       #region IEnumerable<Category> Members
    
       public IEnumerator<Category> GetEnumerator()
       {
          return list.GetEnumerator();
       }
    
       #endregion
    
       #region IEnumerable Members
    
       IEnumerator IEnumerable.GetEnumerator()
       {
          return list.GetEnumerator();
       }
    
       #endregion
    }
