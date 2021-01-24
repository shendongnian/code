    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    
    namespace Microsoft.EntityFrameworkCore
    {
    	public static class AsyncExtensions
    	{
    		public static Task ForEachAsync<T>(this IQueryable<T> source, Func<T, Task> action, CancellationToken cancellationToken = default) =>
    			source.AsAsyncEnumerable().ForEachAsync(action, cancellationToken);
    
    		public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> source, Func<T, Task> action, CancellationToken cancellationToken = default)
    		{
    			using (var asyncEnumerator = source.GetEnumerator())
    				while (await asyncEnumerator.MoveNext(cancellationToken))
    					await action(asyncEnumerator.Current);
    		}
    	}
    }
