    namespace Tvl.UI.ViewModel
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics.Contracts;
        using ICollection = System.Collections.ICollection;
        using IEnumerable = System.Collections.IEnumerable;
        using IEnumerator = System.Collections.IEnumerator;
        using IList = System.Collections.IList;
        public class ViewModelCollection<TViewModel, TModel> : IList<TViewModel>, ICollection<TViewModel>, IEnumerable<TViewModel>, IList, ICollection, IEnumerable
            where TViewModel : class
            where TModel : class
        {
            private readonly IList<TModel> _source;
            private readonly List<KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>>> _viewModelCache =
                new List<KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>>>();
            private readonly Func<TModel, TViewModel> _viewModelFactory;
            public ViewModelCollection(IList<TModel> source, Func<TModel, TViewModel> viewModelFactory)
            {
                if (source == null)
                    throw new ArgumentNullException("source");
                if (viewModelFactory == null)
                    throw new ArgumentNullException("viewModelFactory");
                Contract.EndContractBlock();
                this._source = source;
                this._viewModelFactory = viewModelFactory;
            }
            public int Count
            {
                get
                {
                    return _source.Count;
                }
            }
            bool ICollection<TViewModel>.IsReadOnly
            {
                get
                {
                    return true;
                }
            }
            bool IList.IsReadOnly
            {
                get
                {
                    return true;
                }
            }
            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }
            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }
            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }
            public TViewModel this[int index]
            {
                get
                {
                    if (index < 0)
                        throw new ArgumentOutOfRangeException();
                    if (index > Count)
                        throw new ArgumentException();
                    TModel reference = _source[index];
                    KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>> cached = default(KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>>);
                    if (_viewModelCache.Count > index)
                    {
                        cached = _viewModelCache[index];
                        var cachedModel = cached.Key.Target;
                        var cachedViewModel = cached.Value.Target;
                        if (cachedViewModel != null && object.ReferenceEquals(cachedModel, reference))
                            return cachedViewModel;
                    }
                    while (_viewModelCache.Count <= index)
                    {
                        _viewModelCache.Add(default(KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>>));
                    }
                    var viewModel = _viewModelFactory(reference);
                    _viewModelCache[index] = new KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>>(
                        new WeakReference<TModel>(reference),
                        new WeakReference<TViewModel>(viewModel));
                    return viewModel;
                }
            }
            TViewModel IList<TViewModel>.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    throw new NotSupportedException();
                }
            }
            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    throw new NotSupportedException();
                }
            }
            public int IndexOf(TViewModel item)
            {
                for (int i = 0; i < _viewModelCache.Count; i++)
                {
                    var cachedItem = _viewModelCache[i];
                    var weakViewModel = cachedItem.Value;
                    if (weakViewModel != null && object.ReferenceEquals(weakViewModel.Target, item))
                    {
                        int index = _source.IndexOf(_viewModelCache[i].Key.Target);
                        if (index > 0 && index != i)
                        {
                            while (_viewModelCache.Count <= index)
                                _viewModelCache.Add(default(KeyValuePair<WeakReference<TModel>, WeakReference<TViewModel>>));
                            _viewModelCache[index] = _viewModelCache[i];
                        }
                        return index;
                    }
                }
                return -1;
            }
            public void CopyTo(TViewModel[] array, int arrayIndex)
            {
                for (int i = 0; i < Count; i++)
                    array[arrayIndex + i] = this[i];
            }
            public IEnumerator<TViewModel> GetEnumerator()
            {
                for (int i = 0; i < Count; i++)
                    yield return this[i];
            }
            void ICollection.CopyTo(Array array, int arrayIndex)
            {
                for (int i = 0; i < Count; i++)
                    array.SetValue(this[i], arrayIndex + i);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            void IList<TViewModel>.Insert(int index, TViewModel item)
            {
                throw new NotSupportedException();
            }
            void IList<TViewModel>.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }
            void ICollection<TViewModel>.Add(TViewModel item)
            {
                throw new NotSupportedException();
            }
            void ICollection<TViewModel>.Clear()
            {
                throw new NotSupportedException();
            }
            bool ICollection<TViewModel>.Contains(TViewModel item)
            {
                throw new NotSupportedException();
            }
            bool ICollection<TViewModel>.Remove(TViewModel item)
            {
                throw new NotSupportedException();
            }
            int IList.Add(object item)
            {
                throw new NotSupportedException();
            }
            bool IList.Contains(object item)
            {
                throw new NotSupportedException();
            }
            void IList.Clear()
            {
                throw new NotSupportedException();
            }
            int IList.IndexOf(object item)
            {
                TViewModel viewModel = item as TViewModel;
                if (viewModel == null)
                    return -1;
                return IndexOf(viewModel);
            }
            void IList.Insert(int index, object item)
            {
                throw new NotSupportedException();
            }
            void IList.Remove(object item)
            {
                throw new NotSupportedException();
            }
            void IList.RemoveAt(int index)
            {
                throw new NotSupportedException();
            }
        }
    }
