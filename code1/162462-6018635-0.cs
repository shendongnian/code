    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Interactivity;
    using Infragistics.Windows.DataPresenter;
    namespace Sample {
        public class DataGridExtender : Behavior<XamDataGrid> {
            public readonly static DependencyProperty SelectedDataItemsProperty
                = DependencyProperty.Register(
                    "SelectedDataItems"
                    , typeof(ICollection<object>)
                    , typeof(OzDataGridExtender)
                    , new PropertyMetadata(null));
            public ICollection<object> SelectedDataItems {
                get { return (ICollection<object>)GetValue(SelectedDataItemsProperty); }
                set { SetValue(SelectedDataItemsProperty, value); }
            }
            protected override void OnAttached() {
                base.OnAttached();
                AssociatedObject.SelectedItemsChanged += AssociatedObjectOnSelectedItemsChanged;
                AssociatedObjectOnSelectedItemsChanged(AssociatedObject, null);
            }
            protected override void OnDetaching() {
                AssociatedObject.SelectedItemsChanged -= AssociatedObjectOnSelectedItemsChanged;
                base.OnDetaching();
            }
            private void AssociatedObjectOnSelectedItemsChanged(object sender, Infragistics.Windows.DataPresenter.Events.SelectedItemsChangedEventArgs e) {
                SelectedDataItems = GetSelectedDataItems();
                //AssociatedObject.SetValue(SelectedDataItemsPropertyKey, SelectedDataItems);
            }
            private ICollection<object> GetSelectedDataItems() {
                var selectedItems = from rec in AssociatedObject.SelectedItems.Records.OfType<DataRecord>()
                                    select rec.DataItem;
                return selectedItems.ToList().AsReadOnly();
            }
        }
    }
