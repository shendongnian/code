    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    namespace UI.Helpers
    {
        public class UserControlNameHelper
        {
            public static string GetName(DependencyObject d)
            {
                return (string)d.GetValue(UserControlNameHelper.NameProperty);
            }
    
            public static void SetName(DependencyObject d, string val)
            {
                d.SetValue(UserControlNameHelper.NameProperty, val);
            }
    
            public static readonly DependencyProperty NameProperty =
                DependencyProperty.RegisterAttached("IsTabControlExpander",
                    typeof(string),
                    typeof(UserControlNameHelper),
                    new FrameworkPropertyMetadata("",
                        FrameworkPropertyMetadataOptions.None,
                        (d, e) =>
                        {
                            if (!string.IsNullOrEmpty((string)e.NewValue))
                            {
                                string[] names = e.NewValue.ToString().Split(new char[] { ',' });
                                if (d is FrameworkElement)
                                {
                                    Type t = Type.GetType(names[1]);
                                    if (t == null)
                                        return;
                                    var parent = FindVisualParent(d, t);
                                    if (parent == null)
                                        return;
                                    var p = parent.GetType().GetProperty(names[0], BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
                                    p.SetValue(parent, d, null);
                                }
                            }
                        }));
    
            public static DependencyObject FindVisualParent(DependencyObject child, Type t)
            {
                // get parent item
                DependencyObject parentObject = VisualTreeHelper.GetParent(child);
    
                // we’ve reached the end of the tree
                if (parentObject == null)
                {
                    var p = ((FrameworkElement)child).Parent;
                    if (p == null)
                        return null;
                    parentObject = p;
                }
    
                // check if the parent matches the type we’re looking for
                DependencyObject parent = parentObject.GetType() == t ? parentObject : null;
                if (parent != null)
                {
                    return parent;
                }
                else
                {
                    // use recursion to proceed with next level
                    return FindVisualParent(parentObject, t);
                }
            }
        }
    }
