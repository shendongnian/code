using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
namespace TryThis
{
   public interface IContainer&lt;T&gt;
   {
      IEnumerable&lt;IContent&lt;T&gt;&gt; Contents { get; }
   }
   public interface IContent&lt;T&gt;
   { 
      T GetMyContent(); 
   }
   public interface IProperty 
   { }
   public class Content&lt;T&gt; : IContent&lt;T&gt;
   {
      T m_content = default(T);
      public T GetMyContent() { return m_content; }
      public Content(T val) { m_content = val; }
   }
   public class Contents&lt;T&gt; : IEnumerable&lt;IContent&lt;T&gt;&gt;
   {
      List&lt;IContent&lt;T&gt;&gt; m_contents = new List&lt;IContent&lt;T&gt;&gt;();
      IEnumerator&lt;IContent&lt;T&gt;&gt; IEnumerable&lt;IContent&lt;T&gt;&gt;.GetEnumerator() { return m_contents.GetEnumerator(); }
      IEnumerator IEnumerable.GetEnumerator() { return m_contents.GetEnumerator(); }
      public Contents(params T[] contents) { foreach (T item in contents) m_contents.Add(new Content&lt;T&gt;(item)); }
   }
   public class TestGenericContent : IContainer&lt;int&gt;
   {
      public IContainer&lt;int&gt; GetContainer(IProperty property) { return this; }
      public IEnumerable&lt;IContent&lt;int&gt;&gt; Contents { get { return new Contents&lt;int&gt;(1, 2, 3); } }
   }
   public static class TryThisOut
   {
      static void Test2(object o)
      {
         Type t = o.GetType();
         Type tInterface = t.GetInterface("IContainer`1"); //could be null if o does not implement IContainer&lt;T&gt;
         Type tGenericArg = tInterface.GetGenericArguments()[0]; //extracts T from IContainer&lt;T&gt;
         MethodInfo info = t.GetMethod("GetContainer");
         IProperty propArg = null; //null in this example
         object oContainer = info.Invoke(o, new object[] { propArg });
         PropertyInfo prop = tInterface.GetProperty("Contents");
         object oContents = prop.GetGetMethod().Invoke(oContainer, null);
         //oContents is of type IEnumerable&lt;IContent&lt;T&gt;&gt;, which derives from IEnumerable, so we can cast
         IEnumerable enumeratedContents = oContents as IEnumerable;
         MethodInfo getContentItem = typeof(IContent&lt;&gt;).MakeGenericType(tGenericArg).GetMethod("GetMyContent");
         foreach (object item in enumeratedContents)
         {            
            object oContentItem = getContentItem.Invoke(item, null);
            Debug.Print("Item {0} of type {1}", oContentItem, oContentItem.GetType());
            //...
         }
      }
      public static void Test()
      {
         object o = new TestGenericContent();
         Test2(o);
      }
   }
}
