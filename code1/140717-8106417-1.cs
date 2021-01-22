    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace ItemsControlWithSeperator
    {
    
        public class ViewModel
        {
            public string[] Data { get { return new[] { "Amy", "Bob", "Charlie" }; } }
        }
    
        public class SeperatedItemsControl : ItemsControl
        {
    
            public Style ItemContainerStyle
            {
                get { return (Style)base.GetValue(SeperatedItemsControl.ItemContainerStyleProperty); }
                set { base.SetValue(SeperatedItemsControl.ItemContainerStyleProperty, value); }
            }
    
            public static readonly DependencyProperty ItemContainerStyleProperty =
                DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(SeperatedItemsControl), null);
    
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new SeperatedItemsControlItem();
            }
            protected override bool IsItemItsOwnContainerOverride(object item)
            {
                return item is SeperatedItemsControlItem;
            }
            protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
            {
                //begin code copied from ListBox class
                if (object.ReferenceEquals(element, item))
                {
                    return;
                }
    
                ContentPresenter contentPresenter = element as ContentPresenter;
                ContentControl contentControl = null;
                if (contentPresenter == null)
                {
                    contentControl = (element as ContentControl);
                    if (contentControl == null)
                    {
                        return;
                    }
                }
                DataTemplate contentTemplate = null;
                if (this.ItemTemplate != null && this.DisplayMemberPath != null)
                {
                    throw new InvalidOperationException();
                }
                if (!(item is UIElement))
                {
                    if (this.ItemTemplate != null)
                    {
                        contentTemplate = this.ItemTemplate;
                    }
    
                }
                if (contentPresenter != null)
                {
                    contentPresenter.Content = item;
                    contentPresenter.ContentTemplate = contentTemplate;
                }
                else
                {
                    contentControl.Content = item;
                    contentControl.ContentTemplate = contentTemplate;
                }
    
                if (ItemContainerStyle != null && contentControl.Style == null)
                {
                    contentControl.Style = ItemContainerStyle;
                }
                //end code copied from ListBox class
                if (this.Items.Count > 0)
                {
                    if (object.ReferenceEquals(this.Items[0], item))
                    {
                        var container = element as SeperatedItemsControlItem;
                        container.IsFirstItem = true;
                    }
                }
            }
            
        }
    
        public class SeperatedItemsControlItem : ContentControl
        {
            public bool IsFirstItem { get; set; }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
    
                if (IsFirstItem)
                {
                    var seperator = this.GetTemplateChild("seperator") as FrameworkElement;
                    if (seperator != null)
                    {
                        seperator.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
    }
