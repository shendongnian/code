using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace HQ.Util.Wpf.WpfUtil.Collections
{
	public interface IEnumAndCount<out T> : IEnumerable<T>
	{
		int Count { get; }
	}
	public class ObservableCollectionForFastEnumDerivedCount<T> : 
		ObservableCollection<T>, IEnumAndCount<T>
	{
	}
}
