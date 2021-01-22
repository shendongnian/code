    namespace Tvl.UI.ViewModel
    {
        using System;
        using System.Collections.Generic;
        using System.Collections.Specialized;
        using System.Diagnostics.Contracts;
        using System.Linq;
        public static class ViewModelCollection
        {
            public static IList<TViewModel> Create<TViewModel, TModel>(IEnumerable<TModel> source, Func<TModel, TViewModel> viewModelFactory)
                where TViewModel : class
                where TModel : class
            {
                if (source == null)
                    throw new ArgumentNullException("source");
                if (viewModelFactory == null)
                    throw new ArgumentNullException("viewModelFactory");
                Contract.EndContractBlock();
                INotifyCollectionChanged observable = source as INotifyCollectionChanged;
                if (observable != null)
                    return new ObservableViewModelCollection<TViewModel, TModel>(observable, viewModelFactory);
                IList<TModel> list = source as IList<TModel>;
                if (list == null)
                    list = source.ToArray();
                return new ViewModelCollection<TViewModel, TModel>(list, viewModelFactory);
            }
        }
    }
