    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using H = System.Windows.LogicalTreeHelper;
    using FE = System.Windows.FrameworkElement;
    using DO = System.Windows.DependencyObject;
    using System.Reflection;
    using System.Windows.Markup;
    
    namespace DependencyContentTest
    {
    	public interface IChangeNotifer {
    		/// <summary>Dispatched when this object was modified.</summary>
    		event Action<object> MODIFIED;
    	}
    
    	/// <summary>This element tracks nested <see cref="IChangeNotifer"/> descendant objects (in logical tree) of this object's parent element and resets a child in it's panel property.
    	/// Only static (XAML) objects are supported i.e. object added to the tree dynamically at runtime will not be tracked.</summary>
    	public class UIReseter : UIElement {
    
    		public int searchDepth { get; set; } = int.MaxValue;
    
    		protected override void OnVisualParentChanged(DO oldParent){
    			if (VisualParent is FE p) p.Loaded += (s, e)  =>  bind(p);
    		}
    
    		private void bind(FE parent, int dl = 0) {
    			if (parent == null || dl > searchDepth) return;
    			var chs = H.GetChildren(parent);
    			foreach (object ch in chs) {
    				if (ch is UIReseter r && r != this) throw new Exception($@"There's overlapping ""{nameof(UIReseter)}"" instance in the tree. Use single global instance of check ""{nameof(UIReseter.searchDepth)}"" levels.");
    				if (ch is IChangeNotifer sc) trackObject(sc, parent);
    				else bind(ch as FE, ++dl);
    			}
    		}
    
    		private Dictionary<IChangeNotifer, Reseter> tracked = new Dictionary<IChangeNotifer, Reseter>();
    		private void trackObject(IChangeNotifer sc, FE parent) {
    			var cp = getContentProperty(parent);
    			if (cp == null) return;
    			var r = tracked.nev(sc, () => new Reseter {
    				child = sc,
    				parent = parent,
    				content = cp,
    			});
    			r.track();
    		}
    
    		private PropertyInfo getContentProperty(FE parent) {
    			var pt = parent.GetType();
    			var cp = parent.GetType().GetProperties(
    				BindingFlags.Public |
    				BindingFlags.Instance
    			).FirstOrDefault(i => Attribute.IsDefined(i,
    				typeof(ContentPropertyAttribute)));
    			return cp ?? pt.GetProperty("Content");
    		}
    
    		private class Reseter {
    			public DO parent;
    			public IChangeNotifer child;
    			public PropertyInfo content;
    			private bool isTracking = false;
    
    			/// <summary>Function called by <see cref="IChangeNotifer"/> on <see cref="IChangeNotifer.MODIFIED"/> event.</summary>
    			/// <param name="ch"></param>
    			public void reset(object ch) {
    				if(! isChildOf(child, parent)) return;
    				//TODO: Handle multi-child parents
    				content.SetValue(parent, null);
    				content.SetValue(parent, child);
    			}
    
    			public void track() {
    				if (isTracking) return;
    				child.MODIFIED += reset;
    			}
    
    			private bool isChildOf(IChangeNotifer ch, DO p) {
    				if(ch is DO dch) {
    					if (H.GetParent(dch) == p) return true;
    					child.MODIFIED -= reset; isTracking = false;
    					return false;
    				}
    				var chs = H.GetChildren(p);
    				foreach (var c in chs) if (c == ch) return true;
    				child.MODIFIED -= reset; isTracking = false;
    				return false;
    			}
    		}
    	}
    
    	public static class DictionaryExtension {
    		public static V nev<K,V>(this Dictionary<K,V> d, K k, Func<V> c) {
    			if (d.ContainsKey(k)) return d[k];
    			var v = c(); d.Add(k, v); return v;
    		}
    	}
    	
    }
