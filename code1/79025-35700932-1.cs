    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Linq;
    
    namespace Helpers
    {
        public class ObservableViewModelCollection<TViewModel, TModel> : ObservableCollection<TViewModel>
        {
            private readonly Func<TModel, TViewModel> _viewModelFactory;
            private readonly Action<TViewModel> _viewModelRemoveHandler;
            private ObservableCollection<TModel> _source;
    
            public ObservableViewModelCollection(Func<TModel, TViewModel> viewModelFactory, Action<TViewModel> viewModelRemoveHandler = null)
            {
                Contract.Requires(viewModelFactory != null);
    
                _viewModelFactory = viewModelFactory;
                _viewModelRemoveHandler = viewModelRemoveHandler;
            }
    
            public ObservableCollection<TModel> Source
            {
                get { return _source; }
                set
                {
                    if (_source == value)
                        return;
    
                    this.Clear();
    
                    if (_source != null)
                        _source.CollectionChanged -= OnSourceCollectionChanged;
    
                    _source = value;
                    foreach (var model in _source)
                    {
                        this.Add(CreateViewModel(model));
                    }
    
                    if (_source != null)
                        _source.CollectionChanged += OnSourceCollectionChanged;
                }
            }
    
            private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            this.Insert(e.NewStartingIndex + i, CreateViewModel((TModel)e.NewItems[i]));
                        }
                        break;
    
                    case NotifyCollectionChangedAction.Move:
                        if (e.OldItems.Count == 1)
                        {
                            this.Move(e.OldStartingIndex, e.NewStartingIndex);
                        }
                        else
                        {
                            List<TViewModel> items = this.Skip(e.OldStartingIndex).Take(e.OldItems.Count).ToList();
                            for (int i = 0; i < e.OldItems.Count; i++)
                                this.RemoveAt(e.OldStartingIndex);
    
                            for (int i = 0; i < items.Count; i++)
                                this.Insert(e.NewStartingIndex + i, items[i]);
                        }
                        break;
    
                    case NotifyCollectionChangedAction.Remove:
                        for (int i = 0; i < e.OldItems.Count; i++)
                            this.RemoveAtWithHandling(e.OldStartingIndex);
                        break;
    
                    case NotifyCollectionChangedAction.Replace:
                        // remove
                        for (int i = 0; i < e.OldItems.Count; i++)
                            this.RemoveAtWithHandling(e.OldStartingIndex);
    
                        // add
                        goto case NotifyCollectionChangedAction.Add;
    
                    case NotifyCollectionChangedAction.Reset:
                        Clear();
                        for (int i = 0; i < e.NewItems.Count; i++)
                            this.Add(CreateViewModel((TModel)e.NewItems[i]));
                        break;
    
                    default:
                        break;
                }
            }
    
            private TViewModel CreateViewModel(TModel model)
            {
                return _viewModelFactory(model);
            }
    
    
            private void RemoveAtWithHandling(int index)
            {
                _viewModelRemoveHandler?.Invoke(this[index]);
                this.RemoveAt(index);
            }
        }
    }
