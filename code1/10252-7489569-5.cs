using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace HQ.Util.Wpf.WpfUtil.Collections
{
    public interface IEnumAndCount&lt;out T&gt; : IEnumerable&lt;T&gt;
    {
        int Count { get; }
    }
    public class ObservableCollectionForFastEnumDerivedCount&lt;T&gt; : 
        ObservableCollection&lt;T&gt;, IEnumAndCount&lt;T&gt;
    {
    }
}
